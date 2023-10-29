using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events.ShopInventory;
using Kelontong.Events.Story;
using Kelontong.StoryData;
using UnityEngine;

namespace Kelontong.TEMP_ARYA
{
    public class InkTestingModule : BaseModule
    {
        protected override async Task OnLoad()
        {
            GlobalEvents.Fire(new AddMoneyToShopEvent(10000));
            
            GlobalEvents.Fire(new LoadStoryEvent("main"));
            
            UnityEvents.onUpdate += OnUpdate;
        }

        protected override Task OnUnload()
        {
            UnityEvents.onUpdate -= OnUpdate;

            return base.OnUnload();
        }

        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R)) GlobalEvents.Fire(new StartStoryEvent("day1Customer.presentProduct"));
            if (Input.GetKeyDown(KeyCode.T)) GlobalEvents.Fire(new StartStoryEvent("day1Customer.random"));
        }
    }
}