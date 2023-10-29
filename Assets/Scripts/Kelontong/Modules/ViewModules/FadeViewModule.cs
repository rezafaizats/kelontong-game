using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Views;

namespace Kelontong.Modules.ViewModules
{
    public struct StartFadeInEvent { public float duration; }
    public struct StartFadeOutEvent { public float duration; }
    
    public class FadeViewModule : ViewModule<FadeView>,
        IEventListener<StartFadeInEvent>,
        IEventListener<StartFadeOutEvent>
    {
        public static void FadeIn(float duration) => GlobalEvents.Fire(new StartFadeInEvent() {duration = duration});
        public static void FadeOut(float duration) => GlobalEvents.Fire(new StartFadeOutEvent() {duration = duration});
        
        public void OnEvent(StartFadeInEvent data)
        {
            view.StartFadeIn(data.duration);
        }

        public void OnEvent(StartFadeOutEvent data)
        {
            view.StartFadeOut(data.duration);
        }
    }
}