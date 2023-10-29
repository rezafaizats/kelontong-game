using System;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Minigames
{
    class TelurViewModule : ViewModule<TelurView>, IEventListener<OnSubmitTelurEvent>, IEventListener<OnEggAdded>, IEventListener<OnEggRemoved>
    {
        private const string productId = "telur";
        private float currenTotalWeight = 0;
        private float shopEggWeight = 0;
        private int totalEgg = 0;

        public float GetWeight => currenTotalWeight;

        protected override async Task OnLoad()
        {
            await base.OnLoad();
        }

        protected override void OnOpen()
        {
            var queryResult = GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(new QueryProductFromShop(productId));
            if(!queryResult.found) throw new Exception("Product doesn't exist!");
            shopEggWeight = queryResult.quantity;

            totalEgg = (int)(shopEggWeight / 250f);
            if(totalEgg >= 8) totalEgg = 8;

            view.DisplayEgg(totalEgg);
            base.OnOpen();
        }

        public void OnEvent(OnSubmitTelurEvent data)
        {
            GlobalEvents.Fire(new AddProductToPlayerEvent(productId, currenTotalWeight));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(productId, currenTotalWeight));
        }

        public void OnEvent(OnEggAdded data)
        {
            currenTotalWeight += data.eggWeight;
            totalEgg -= data.eggAmount;
            view.DisplayWeight(currenTotalWeight);
        }

        public void OnEvent(OnEggRemoved data)
        {
            currenTotalWeight -= data.eggWeight;
            totalEgg += data.eggAmount;
            view.DisplayWeight(currenTotalWeight);
        }
    }
}