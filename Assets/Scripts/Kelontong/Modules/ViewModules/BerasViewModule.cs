using System;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames.Beras;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;
using Unity.VisualScripting;

namespace Kelontong.Modules.ViewModules
{
    public class BerasViewModule : ViewModule<BerasView>, IEventListener<OnBerasPressedNumberEvent>, IEventListener<OnBerasSubmitEvent>, IEventListener<OnBerasNumberClearEvent>
    {
        private const string productId = "beras";

        private float shopInventoryWeightBeras = 0;
        private float tempShopInventoryWeightBeras = 0;
        private float totalWeightBeras = 0;

        protected override void OnOpen()
        {
            var queryResult =
                GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(
                    new QueryProductFromShop(productId));
            if(!queryResult.found) throw new Exception("Product doesn't exist!");
            
            shopInventoryWeightBeras = queryResult.quantity;
            tempShopInventoryWeightBeras = shopInventoryWeightBeras;
            view.DisplayShopInventory(shopInventoryWeightBeras);
            
            base.OnOpen();
        }

        public void OnEvent(OnBerasPressedNumberEvent data)
        {
            var currentWeight = shopInventoryWeightBeras - data.berasValue;
            if(currentWeight <= 0f) return;

            totalWeightBeras = totalWeightBeras + data.berasValue;
            shopInventoryWeightBeras = currentWeight;
            view.DisplayWeight(totalWeightBeras);
            view.DisplayShopInventory(shopInventoryWeightBeras);
        }

        public void OnEvent(OnBerasSubmitEvent data)
        {
            GlobalEvents.Fire(new AddProductToPlayerEvent(productId, totalWeightBeras));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(productId, totalWeightBeras));
        }

        public void OnEvent(OnBerasNumberClearEvent data)
        {
            totalWeightBeras = 0;
            shopInventoryWeightBeras = tempShopInventoryWeightBeras;
            view.DisplayWeight(totalWeightBeras);
            view.DisplayShopInventory(shopInventoryWeightBeras);
        }
    }
}