using System.Collections.Generic;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events.ShopInventory;
using Kelontong.Products;
using Kelontong.StoryData;
using UnityEngine;

namespace Kelontong.Modules
{
    public class ShopInventoryModule : BaseModule,
        IEventListener<AddProductToShopEvent>,
        IEventListener<RemoveProductFromShopEvent>,
        IEventListener<AddMoneyToShopEvent>,
        IEventListener<RemoveMoneyFromShopEvent>,
        IQueryProvider<QueryProductFromShopResult, QueryProductFromShop>,
        IQueryProvider<QueryMoneyFromShop>
    {
        private int money = 0;
        private Dictionary<string, float> products;

        public void OnEvent(AddProductToShopEvent data)
        {
            if (products.ContainsKey(data.productId)) products[data.productId] += data.value;
            else products[data.productId] = data.value;
            
            GlobalEvents.Fire(new OnShopInventoryUpdated(products));
        }

        public void OnEvent(RemoveProductFromShopEvent data)
        {
            if (!products.TryGetValue(data.productId, out var quantity))
            {
                Debug.LogError($"Trying to Remove {data.productId} from shop but it doesn't exist!");
                return;
            }

            if (quantity - data.quantity < 0) products.Remove(data.productId);
            else products[data.productId] = quantity - data.quantity;
            
            GlobalEvents.Fire(new OnShopInventoryUpdated(products));
        }

        public QueryProductFromShopResult OnQuery(QueryProductFromShop data)
        {
            if (!products.TryGetValue(data.id, out var quantity)) return new();
            
            if (!ProductDatabase.TryGet(data.id, out var productData)) return new();

            return new(quantity, productData);
        }

        public QueryMoneyFromShop OnQuery() => new(money);
        public void OnEvent(AddMoneyToShopEvent data)
        {
            var oldValue = money;
            money += data.value;
            GlobalEvents.Fire(new OnMoneyUpdated(oldValue, money));
        }

        public void OnEvent(RemoveMoneyFromShopEvent data)
        {
            var oldValue = money;
            money = Mathf.Clamp(money - data.value, 0, money);
            GlobalEvents.Fire(new OnMoneyUpdated(oldValue, money));
        }

        [StoryEvent]
        public static void AddMoney(int amount)
        {
            GlobalEvents.Fire(new AddMoneyToShopEvent(amount));
        }
    }
}