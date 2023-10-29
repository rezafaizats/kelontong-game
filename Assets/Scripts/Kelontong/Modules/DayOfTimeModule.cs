using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events;
using UnityEngine;

namespace Kelontong.Modules
{
    public interface IDayOfTimeHandle
    {
        
    }
    
    public class DayOfTimeModule : BaseModule, IDayOfTimeHandle,
        IEventListener<SetDayEvent>, 
        IEventListener<StartDayEvent>, 
        IQueryProvider<QueryDay>,
        IQueryProvider<TimeHandleQueryResult> 
    {
        private int day = 1;
        private float currentNormalizedTime = 0f;
        private float dayMinuteLength = 5f;
        private bool isRunning = false;

        protected override Task OnLoad()
        {
            UnityEvents.onUpdate += Update;
            return base.OnLoad();
        }

        protected override Task OnUnload()
        {
            UnityEvents.onUpdate -= Update;
            return base.OnUnload();
        }

        private void Update()
        {
            if (!isRunning) return;
            
            if (currentNormalizedTime > 1f)
            {
                StopDay();
                return;
            }

            var time = Time.deltaTime / (dayMinuteLength * 60f);
            currentNormalizedTime += time;
        }


        public void OnEvent(StartDayEvent data)
        {
            isRunning = true;
         
            GlobalEvents.Fire(new OnDayStartedEvent(){ day = day });
        }

        private void StopDay()
        {
            isRunning = false;
            
            GlobalEvents.Fire(new OnDayEndedEvent());
        }

        public TimeHandleQueryResult OnQuery() => new(this);
        public void OnEvent(SetDayEvent data)
        {
            day = data.day;
        }

        QueryDay IQueryProvider<QueryDay>.OnQuery()
        {
            return new() {day = day};
        }
    }
}