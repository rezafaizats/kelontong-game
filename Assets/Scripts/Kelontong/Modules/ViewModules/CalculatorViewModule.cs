using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Calculator;
using Kelontong.Events;
using Kelontong.Events.Calculator;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules.ViewModules
{
    public class CalculatorViewModule : ViewModule<CalculatorView>,
        IEventListener<DisplayNumberCalculatorEvent>, IEventListener<OnCalculatorPressedEvent>
    {

        protected override async Task OnLoad()
        {
            await base.OnLoad();
            view.Display(0);
        }

        public void OnEvent(DisplayNumberCalculatorEvent data)
        {
            view.Display(data.number);
        }
        
        public void OnEvent(OnCalculatorPressedEvent data)
        {
            Debug.Log("tombol di pencet");
            if (data.pressedButton is CalculatorNumberButton calculatorNumberButton)
            {
                Debug.Log("ini tombol number"+" "+calculatorNumberButton.Number);
            }else if (data.pressedButton is CalculatorOperationButton calculatorOperationButton)
            {
                Debug.Log("ini tombol operasi" + " " + calculatorOperationButton.Operation);
            }
            
            
        }
    }
}