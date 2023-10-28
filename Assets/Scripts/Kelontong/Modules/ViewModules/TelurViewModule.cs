using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames;
using Kelontong.Views;

namespace Kelontong.Minigames
{
    class TelurViewModule : ViewModule<TelurView>, IEventListener<OnSubmitTelurEvent>, IEventListener<OnEggAdded>, IEventListener<OnEggRemoved>
    {
        private float currenTotalWeight;
        private int totalEgg = 10;

        public float GetWeight => currenTotalWeight;

        protected override async Task OnLoad()
        {
            await base.OnLoad();
            view.DisplayEgg(totalEgg);
        }

        public void OnEvent(OnSubmitTelurEvent data)
        {
            GlobalEvents.Fire(new OnSubmitTelurEvent(totalEgg, currenTotalWeight));
        }

        public void OnEvent(OnEggAdded data)
        {
            currenTotalWeight += data.eggWeight;
            totalEgg -= data.eggAmount;
            view.DisplayWeight(currenTotalWeight);
        }

        public void OnEvent(OnEggRemoved data)
        {
            currenTotalWeight -= data.eggWeight;
            totalEgg += data.eggAmount;
            view.DisplayWeight(currenTotalWeight);
        }
    }
}