using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames;
using Kelontong.UI.Minigames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Kelontong.Views
{
    class MinyakTanahView : View
    {
        [SerializeField] private Image oilImage;
        [SerializeField] private MinyakMinigameButton fillButton;
        [SerializeField] private Button submitButton;
        
        [SerializeField] private float fillSpeed;

        public void FillBeaker(float fillRate) {
            oilImage.fillAmount = fillSpeed * fillRate;
        }

        protected override void OnOpen()
        {
            fillButton.fillRate = fillSpeed;
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