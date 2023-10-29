using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Calculator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class CalculatorView : View
    {
        [SerializeField] private TextMeshProUGUI calculatorText;
        [SerializeField] private Button submitButton;

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
        }
    }
}
