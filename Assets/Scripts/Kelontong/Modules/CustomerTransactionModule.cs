using System.Collections.Generic;
using System.Linq;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events;
using Kelontong.Events.CustomerTransactions;
using Kelontong.Events.ShopInventory;

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
            //???
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
            //Get Products
            //Generate Expected Price
        }

        public int OnQuery(QueryPrice data) => submittedPrice;

        public float OnQuery(QueryFulfillmentScore data)
        {
            //calculate based on amount and expected price
            return 0f;
        }

        public QueryProductRequestResult OnQuery(QueryProductRequest data)
        {
            var entry = currentRequest.ElementAt(data.index);
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