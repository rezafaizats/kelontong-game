using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.Story;
using Kelontong.Views;

namespace Kelontong.Modules.ViewModules
{
    public class IntroViewModule : ViewModule<IntroView>,
        IEventListener<OnStoryEndEvent>,
        IEventListener<OnStoryLineEvent>
    {
        protected override async Task OnLoad()
        {
            await base.OnLoad();
            
            var day = GlobalEvents.Query<QueryDay>().day;
            GlobalEvents.Fire(new LoadStoryEvent("main"));
            GlobalEvents.Fire(new StartStoryEvent($"Introduction.Day{day}"));
        }

        public void OnEvent(OnStoryLineEvent data)
        {
           view.DisplayLine(data.line);        
        }

        public void OnEvent(OnStoryEndEvent data)
        {
            GlobalEvents.Fire(new OnIntroEndEvent());
        }
    }
}