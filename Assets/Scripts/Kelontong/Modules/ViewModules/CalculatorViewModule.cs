using System;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Calculator;
using Kelontong.Events;
using Kelontong.Events.Calculator;
using Kelontong.Views;
using TMPro;
using UnityEngine;

namespace Kelontong.Modules.ViewModules
{
    public class CalculatorViewModule : ViewModule<CalculatorView>, IEventListener<OnCalculatorPressedEvent>
    {
        private int currentNumber;
        private int lastNumber;
        private CalculatorOperation currentOperation = CalculatorOperation.NONE;

        protected override async Task OnLoad()
        {
            await base.OnLoad();
            view.Display(0);
        }
        
        public void OnEvent(OnCalculatorPressedEvent data)
        {
            if (data.pressedButton is CalculatorNumberButton calculatorNumberButton)
            {
                string numberString = currentNumber.ToString();
                if (numberString.Length >= 7)return;
                currentNumber = currentNumber * 10 + calculatorNumberButton.Number;
                view.Display(currentNumber);
                
            }else if (data.pressedButton is CalculatorOperationButton calculatorOperationButton)
            {
                switch (calculatorOperationButton.Operation)
                {
                    case CalculatorOperation.PLUS:
                    case CalculatorOperation.MINUS:
                    case CalculatorOperation.MULTIPLY:
                    case CalculatorOperation.DIVIDE:
                        if (currentOperation == CalculatorOperation.NONE)
                        {
                            lastNumber = currentNumber;
                            currentNumber = 0;
                        }
                        else
                        {
                            lastNumber = Operate(lastNumber, currentNumber, calculatorOperationButton.Operation);
                            currentNumber = 0;
                            view.Display(lastNumber);
                        } 
                        currentOperation = calculatorOperationButton.Operation;
                        break;
                    case CalculatorOperation.CLEAR:
                        currentNumber = 0;
                        view.Display(currentNumber);
                        currentOperation = CalculatorOperation.NONE;
                        break;
                    case CalculatorOperation.DELETE:
                        currentNumber = Mathf.FloorToInt(currentNumber / 10f);
                        view.Display(currentNumber);
                        break;
                    case CalculatorOperation.EQUALS:
                        if (currentOperation == CalculatorOperation.EQUALS)
                        {
                            return;
                        }
                        currentNumber = Operate(lastNumber, currentNumber, currentOperation);
                        view.Display(currentNumber);
                        currentOperation = CalculatorOperation.NONE;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }

        public int Operate(int firstNumber, int secondNumber, CalculatorOperation operation)
        {
            switch (operation)
            {
                case CalculatorOperation.PLUS:
                    return firstNumber + secondNumber;
                case CalculatorOperation.MINUS:
                    return firstNumber - secondNumber;
                case CalculatorOperation.MULTIPLY:
                    return firstNumber * secondNumber;
                case CalculatorOperation.DIVIDE:
                    return firstNumber / secondNumber;

                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }












        // public void OnEvent(OnCalculatorPressedEvent data)
        // {
        //     if (data.pressedButton is CalculatorNumberButton calculatorNumberButton)
        //     {
        //         currentNumber = currentNumber * 10 + calculatorNumberButton.Number;
        //         view.Display(currentNumber);
        //
        //     }else if (data.pressedButton is CalculatorOperationButton calculatorOperationButton)
        //     {
        //         
        //         switch (calculatorOperationButton.Operation)
        //         {
        //             
        //             case CalculatorOperation.PLUS:
        //                 lastNumber = lastNumber + currentNumber;
        //                 currentNumber = 0;
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.MINUS:
        //                 lastNumber = lastNumber - currentNumber;
        //                 currentNumber = 0;
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.MULTIPLY:
        //                 lastNumber = lastNumber * currentNumber;
        //                 currentNumber = 0;
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.DIVIDE:
        //                 lastNumber = lastNumber / currentNumber;
        //                 currentNumber = 0;
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.CLEAR:
        //                 currentNumber = 0;
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.DELETE:
        //                 currentNumber = Mathf.FloorToInt(currentNumber / 10f);
        //                 view.Display(currentNumber);
        //                 break;
        //             case CalculatorOperation.EQUALS:
        //                 view.Display(lastNumber);
        //                 break;
        //         }
        //     }
        //     
        //     
        // }



    }
}