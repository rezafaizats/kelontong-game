using Kelontong.Calculator;
using UnityEngine;

namespace Kelontong.Events.Calculator
{
    public struct OnCalculatorPressedEvent
    {
        public CalculatorButton pressedButton;
        
        public OnCalculatorPressedEvent(CalculatorButton pressedButton)
        {
            this.pressedButton = pressedButton;
        }
    }
}