using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Minigames;
using Kelontong.Views;

namespace Kelontong.Minigames
{
    class MinyakTanahViewModule : ViewModule<MinyakTanahView>, IEventListener<OnMinyakTanahPressedEvent>, IEventListener<OnMinyakTanahSubmitEvent>
    {
        private int minyakAmount;

        public void OnEvent(OnMinyakTanahPressedEvent data)
        {
            throw new System.NotImplementedException();
        }

        public void OnEvent(OnMinyakTanahSubmitEvent data)
        {
            GlobalEvents.Fire(new OnSubmitMinyakTanah(minyakAmount));
        }
    }
}