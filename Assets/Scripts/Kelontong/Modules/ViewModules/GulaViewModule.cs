using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames.Gula;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;

namespace Kelontong.Modules.ViewModules
{
    public class GulaViewModule : ViewModule<GulaView>, IEventListener<OnGulaPressedNumberEvent>, IEventListener<OnGulaSubmitEvent>, IEventListener<OnGulaNumberClearEvent>
    {
        private const string productId = "gula";
        
        private float shopInventoryWeightGula = 0;
        private float tempShopInventoryWeightGula = 0;
        private float totalWeightGula = 0;

        protected override void OnOpen()
        {
            var queryResult =
                GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(
                    new QueryProductFromShop(productId));
            if (!queryResult.found) throw new Exception("Product doesn't exist!");

            shopInventoryWeightGula = queryResult.quantity;
            tempShopInventoryWeightGula = shopInventoryWeightGula;
            view.DisplayShopInventory(shopInventoryWeightGula);
            
            base.OnOpen();
        }

        public void OnEvent(OnGulaPressedNumberEvent data)
        {
            var currentWeight = shopInventoryWeightGula - data.gulaValue;
            if (currentWeight <= 0f) return;

            totalWeightGula = totalWeightGula + data.gulaValue;
            shopInventoryWeightGula = currentWeight;
            view.DisplayWeight(totalWeightGula);
            view.DisplayWeight(shopInventoryWeightGula);
        }

        public void OnEvent(OnGulaSubmitEvent data)
        {
            GlobalEvents.Fire(new AddProductToPlayerEvent(productId, totalWeightGula));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(productId, totalWeightGula));
        }

        public void OnEvent(OnGulaNumberClearEvent data)
        {
            totalWeightGula = 0;
            shopInventoryWeightGula = tempShopInventoryWeightGula;
            view.DisplayWeight(totalWeightGula);
            view.DisplayShopInventory(shopInventoryWeightGula);
        }
    }
}