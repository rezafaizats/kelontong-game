using System.Threading.Tasks;
using Arr.ViewModuleSystem;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules.ViewModules
{
    public class CalculatorViewModule : ViewModule<CalculatorView>
    {
        protected override async Task OnLoad()
        {
            view.Display(1);
        }
    }
}