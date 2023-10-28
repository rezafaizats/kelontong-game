using System;
using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames;
using Kelontong.Views;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Kelontong.Minigames
{
    class MinyakTanahViewModule : ViewModule<MinyakTanahView>, IEventListener<OnMinyakTanahPressedEvent>, IEventListener<OnMinyakTanahReleasedEvent>, IEventListener<OnMinyakTanahSubmitEvent>
    {
        private float minyakAmount;

        public void OnEvent(OnMinyakTanahPressedEvent data)
        {
            minyakAmount += data.fillRate;
        }

        public void OnEvent(OnMinyakTanahReleasedEvent data)
        {

        }

        public void OnEvent(OnMinyakTanahSubmitEvent data)
        {
            GlobalEvents.Fire(new OnSubmitMinyakTanah(minyakAmount));
        }
    }
}