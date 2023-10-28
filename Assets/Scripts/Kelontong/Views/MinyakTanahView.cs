using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Kelontong.Views
{
    class MinyakTanahView : View
    {
        [SerializeField] private Image oilImage;
        [SerializeField] private Button fillButton;
        
        [SerializeField] private float fillSpeed;

        public void FillBeaker(float fillRate) {
            GlobalEvents.Fire(new OnMinyakTanahPressedEvent(fillButton));
            oilImage.fillAmount = fillSpeed * fillRate;
        }

        protected override void OnOpen()
        {
            oilImage.fillAmount = 0f;
            fillButton.onClick.AddListener( () => FillBeaker(1f) );
        }

        protected override void OnClose()
        {
            oilImage.fillAmount = 0f;
            fillButton.onClick.RemoveAllListeners();
        }

    }
}