using UnityEngine;

namespace Kelontong.Calculator
{
    public class CalculatorNumberButton : CalculatorButton
    {
        [SerializeField] private int number;
        public int Number => number;
    }
}