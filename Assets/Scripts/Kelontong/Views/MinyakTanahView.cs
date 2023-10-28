using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
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

        public void FillBeaker(float fillRate) {
            Debug.Log("Filling oil at " + fillRate);
            oilImage.fillAmount = fillRate;
        }

        protected override Task OnLoad()
        {
            fillButton.fillRate = 0.001f;
            Debug.Log("Fill rate is " + fillButton.fillRate);
            oilImage.fillAmount = 0f;
            submitButton.onClick.AddListener(() => GlobalEvents.Fire(new OnMinyakTanahSubmitEvent()));
            return base.OnLoad();
        }

        protected override Task OnUnload()
        {
            oilImage.fillAmount = 0f;
            fillButton.onClick.RemoveAllListeners();
            submitButton.onClick.RemoveAllListeners();
            return base.OnUnload();
        }
    }
}