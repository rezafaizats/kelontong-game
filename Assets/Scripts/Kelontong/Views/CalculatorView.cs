using System;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Calculator;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class CalculatorView : View, IPreventInteraction
    {
        [SerializeField] private TextMeshProUGUI calculatorText;
        [SerializeField] private Button submitButton;
        [SerializeField] private MMF_Player openFeedBack;

        protected override Task OnLoad()
        {
            openFeedBack.Initialization(gameObject);
            return base.OnLoad();
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            openFeedBack.PlayFeedbacks();
        }

        public override bool ActiveOnSpawn => false;

        private void Awake()
        {
            submitButton.onClick.AddListener(SubmitPrice);
        }

        public void Display(int angka)
        {
            calculatorText.text = angka.ToString();
        }

        public void SubmitPrice()
        {
            GlobalEvents.Fire(new OnCalculatorSubmitPriceEvent());
            View.Close<CalculatorView>();
        }
    }
}
