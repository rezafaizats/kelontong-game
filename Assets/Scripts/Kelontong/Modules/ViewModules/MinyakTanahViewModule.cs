using System;
using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Kelontong.Minigames
{
    class MinyakTanahViewModule : ViewModule<MinyakTanahView>, IEventListener<OnMinyakTanahPressedEvent>, IEventListener<OnMinyakTanahReleasedEvent>, IEventListener<OnMinyakTanahSubmitEvent>
    {
        private const string productId = "minyakTanah";
        public float maxMinyakAmount = 1f;
        private float minyakAmount = 0f;
        private float fillRate = 0f;
        private bool isFilling = false;

        protected override Task OnLoad()
        {
            minyakAmount = 0f;
            UnityEvents.onUpdate += Update;
            return base.OnLoad();
        }

        protected override Task OnUnload()
        {
            UnityEvents.onUpdate -= Update;
            return base.OnUnload();
        }

        protected override void OnOpen()
        {
            var queryResult = GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(new QueryProductFromShop(productId));
            if(!queryResult.found) throw new Exception("Product doesn't exist!");
            maxMinyakAmount = queryResult.quantity * 1000;
            base.OnOpen();
        }

        private void Update() {
            if(!isFilling || minyakAmount >= maxMinyakAmount) return;

            minyakAmount += fillRate;
            view.FillBeaker(minyakAmount);
        }

        public void OnEvent(OnMinyakTanahPressedEvent data)
        {
            fillRate = data.fillRate;
            isFilling = true;
        }

        public void OnEvent(OnMinyakTanahReleasedEvent data)
        {
            fillRate = 0f;
            isFilling = false;
        }

        public void OnEvent(OnMinyakTanahSubmitEvent data)
        {
            minyakAmount /= 1000f;
            GlobalEvents.Fire(new AddProductToPlayerEvent(productId, minyakAmount));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(productId, minyakAmount));
            view.Close();
        }
    }
}