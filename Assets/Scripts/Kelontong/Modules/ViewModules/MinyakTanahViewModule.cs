using System;
using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames;
using Kelontong.Views;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Kelontong.Minigames
{
    class MinyakTanahViewModule : ViewModule<MinyakTanahView>, IEventListener<OnMinyakTanahPressedEvent>, IEventListener<OnMinyakTanahReleasedEvent>, IEventListener<OnMinyakTanahSubmitEvent>
    {
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
            GlobalEvents.Fire(new OnSubmitMinyakTanah(minyakAmount));
        }
    }
}