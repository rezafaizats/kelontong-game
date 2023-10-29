using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames.Tepung;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;
using Unity.VisualScripting;

namespace Kelontong.Modules.ViewModules
{
    public class TepungViewModule : ViewModule<TepungView>, IEventListener<OnTepungPressedNumberEvent>, IEventListener<OnTepungSubmitEvent>, IEventListener<OnTepungNumberClearEvent>
    {
        private const string productId = "tepung";

        
        private float shopInventoryWeightTepung = 0;
        private float tempShopInventoryTepung = 0;
        private float totalWeightTepung = 0;

        protected override void OnOpen()
        {
            var queryResult =
                GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(
                    new QueryProductFromShop(productId));
            if (!queryResult.found) throw new Exception("Product doesn't exist!");

            shopInventoryWeightTepung = queryResult.quantity;
            tempShopInventoryTepung = shopInventoryWeightTepung;
            view.DisplayShopInventory(shopInventoryWeightTepung);
            
            base.OnOpen();
        }
        
        public void OnEvent(OnTepungPressedNumberEvent data)
        {
            var currentWeight = shopInventoryWeightTepung - data.tepungValue;
            if (currentWeight <= 0f) return;

            totalWeightTepung = totalWeightTepung + data.tepungValue;
            shopInventoryWeightTepung = currentWeight;
            view.DisplayWeight(totalWeightTepung);
            view.DisplayShopInventory(shopInventoryWeightTepung);
        }

        public void OnEvent(OnTepungSubmitEvent data)
        {
            GlobalEvents.Fire(new AddProductToPlayerEvent(productId, totalWeightTepung));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(productId, totalWeightTepung));
        }

        public void OnEvent(OnTepungNumberClearEvent data)
        {
            totalWeightTepung = 0;
            shopInventoryWeightTepung = tempShopInventoryTepung;
            view.DisplayWeight(totalWeightTepung);
            view.DisplayShopInventory(shopInventoryWeightTepung);
        }
    }
}