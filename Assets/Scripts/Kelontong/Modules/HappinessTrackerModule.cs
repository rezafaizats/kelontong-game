using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events.Calculator;
using UnityEngine;

namespace Kelontong.Modules
{
    public class HappinessTrackerModule : BaseModule
    {
        protected override Task OnLoad()
        {
            Debug.Log("HELLOO");

            return base.OnLoad();
        }
    }
}