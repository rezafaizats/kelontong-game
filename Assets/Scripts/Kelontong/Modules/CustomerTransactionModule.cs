using System;
using System.Collections.Generic;
using System.Linq;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Customer;
using Kelontong.Events;
using Kelontong.Events.CustomerTransactions;
using Kelontong.Events.ShopInventory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kelontong.Modules
{
    public class CustomerTransactionModule : BaseModule,
        IEventListener<StartSaleEvent>,
        IEventListener<RejectSaleEvent>,
        IEventListener<ConsumeProductsEvent>,
        IEventListener<ResetProductRequestEvent>,
        IEventListener<GenerateProductEvent>,
        IEventListener<OnSubmitPriceEvent>,
        IQueryProvider<int, QueryPrice>,
        IQueryProvider<float, QueryFulfillmentScore>,
        IQueryProvider<QueryProductRequestResult, QueryProductRequest>
    {
        private Dictionary<string, float> currentRequest = new();
        private Dictionary<string, int> expectedPricePerUnit = new();
        private int submittedPrice = 0;

        public void OnEvent(StartSaleEvent data)
        {
            
            
        }

        public void OnEvent(RejectSaleEvent data)
        {
            currentRequest = new();
            expectedPricePerUnit = new();
        }

        public void OnEvent(ConsumeProductsEvent data)
        {
            foreach (var req in currentRequest)
            {
                GlobalEvents.Fire(new RemoveProductFromShopEvent()
                {
                    productId = req.Key,
                    quantity = req.Value
                });
            }

            currentRequest = new();
            expectedPricePerUnit = new();
        }

        public void OnEvent(ResetProductRequestEvent data)
        {
            currentRequest = new();
            expectedPricePerUnit = new();
        }

        public void OnEvent(GenerateProductEvent data)
        {
            var count = data.count;
            var customer = GlobalEvents.Query<CustomerProfile, QueryFrontCustomer>(new ());
            var products = customer.GenerateProductRequest();
            if (count > products.Count) throw new Exception("TRYING TO GENERATE PRODUCT MORE THAN PROFILE");

            var randRequest = products
                .OrderBy(x => Random.Range(0, 9999)) //Shuffle with LINQ
                .Take(count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var req in randRequest)
                currentRequest.Add(req.Key, req.Value);

            expectedPricePerUnit = customer.GenerateExpectedPricing();
            
            Debug.Log($"GENERATED {currentRequest.Count} REQUEST");
        }

        public int OnQuery(QueryPrice data) => submittedPrice;

        public float OnQuery(QueryFulfillmentScore data)
        {
            var query = GlobalEvents.Query<QueryPresentedProductResult>();
            var presentedProduct = query.products;

            float quantityFulfillment = 0;
            float priceFulfillment = 0;

            foreach (var item in currentRequest)
            {
                if (presentedProduct.ContainsKey(item.Key))
                {
                    float presentedQuantity = presentedProduct[item.Key];
                    float requestedQuantity = item.Value;
                    float ratio = presentedQuantity / requestedQuantity;

                    if (ratio <= 0.5)
                        quantityFulfillment += -1;
                    else if (ratio >= 2)
                        quantityFulfillment += 1;
                    else
                        quantityFulfillment += 2 * ratio - 1;
                }
                else
                {
                    quantityFulfillment += -1;
                }
            }
            quantityFulfillment /= currentRequest.Count;

            float expectedTotalPrice = 0;
            foreach (var item in currentRequest)
            {
                if (expectedPricePerUnit.TryGetValue(item.Key, out var value))
                {
                    expectedTotalPrice += item.Value * value;
                }
            }

            float priceRatio = submittedPrice / expectedTotalPrice;
            if (priceRatio <= 0.5)
                priceFulfillment = 1;
            else if (priceRatio >= 2)
                priceFulfillment = -1;
            else
                priceFulfillment = 1 - 2 * priceRatio; // Linear interpolation between 1 and -1

            float overallFulfillment = (quantityFulfillment + priceFulfillment) / 2;

            return overallFulfillment;
        }

        public QueryProductRequestResult OnQuery(QueryProductRequest data)
        {
            var entry = currentRequest.ElementAt(data.index);
            Debug.Log($"QueryProductRequestResult, will return {entry.Key} amount {entry.Value}");
            return new()
            {
                productId = entry.Key,
                productAmount = entry.Value
            };
        }

        public void OnEvent(OnSubmitPriceEvent data)
        {
            submittedPrice = data.price;
        }
    }
}