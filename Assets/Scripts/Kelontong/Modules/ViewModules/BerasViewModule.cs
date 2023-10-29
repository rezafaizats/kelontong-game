using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames.Beras;
using Kelontong.Views;

namespace Kelontong.Modules.ViewModules
{
    public class BerasViewModule : ViewModule<BerasView>, IEventListener<OnBerasPressedNumberEvent>, IEventListener<OnBerasSubmitEvent>, IEventListener<OnBerasNumberClearEvent>
    {
        private int totalWeightBeras = 0;
        protected override Task OnLoad()
        {
            return base.OnLoad();
        }

        public void OnEvent(OnBerasPressedNumberEvent data)
        {
            totalWeightBeras = totalWeightBeras + data.berasValue;
            view.DisplayWeight(totalWeightBeras);
        }

        public void OnEvent(OnBerasSubmitEvent data)
        {
            GlobalEvents.Fire(new OnBerasSubmitEvent());
        }

        public void OnEvent(OnBerasNumberClearEvent data)
        {
            totalWeightBeras = 0;
            view.DisplayWeight(totalWeightBeras);
        }
    }
}