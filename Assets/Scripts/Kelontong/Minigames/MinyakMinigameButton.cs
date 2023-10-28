using System.Collections;
using System.Collections.Generic;
using Arr.EventsSystem;
using Kelontong.Events.Minigames;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kelontong.UI.Minigames
{
    public class MinyakMinigameButton : Button
    {
        public float fillRate;

        public override void OnPointerDown(PointerEventData eventData)
        {   
            base.OnPointerDown(eventData);
            GlobalEvents.Fire(new OnMinyakTanahPressedEvent(fillRate));
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            GlobalEvents.Fire(new OnMinyakTanahReleasedEvent());
        }


    }

}