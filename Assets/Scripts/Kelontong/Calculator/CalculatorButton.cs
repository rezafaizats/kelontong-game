using System;
using Arr.EventsSystem;
using Kelontong.Events.Calculator;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Calculator
{
    public class CalculatorButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            GlobalEvents.Fire(new OnCalculatorPressedEvent(this));
        }
        
        
    }
}