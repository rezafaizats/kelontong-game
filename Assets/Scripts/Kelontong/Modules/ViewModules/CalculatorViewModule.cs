using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Calculator;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules.ViewModules
{
    public class CalculatorViewModule : ViewModule<CalculatorView>,
        IEventListener<DisplayNumberCalculatorEvent>
    {

        protected override async Task OnLoad()
        {
            await base.OnLoad();
            view.Display(1);
        }

        public void OnEvent(DisplayNumberCalculatorEvent data)
        {
            view.Display(data.number);
        }
    }
}