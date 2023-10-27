using UnityEngine;

namespace Kelontong.Calculator
{
    public class CalculatorOperationButton : CalculatorButton
    {
        [SerializeField] private CalculatorOperation operation;
        public CalculatorOperation Operation => operation;
    }
}