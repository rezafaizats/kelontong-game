using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Story;
using Kelontong.Views;

namespace Kelontong.Modules.ViewModules
{
    public class DialogueViewModule : ViewModule<DialogueView>,
        IEventListener<OnStoryLineEvent>,
        IEventListener<OnStoryChoiceEvent>,
        IEventListener<OnStoryEndEvent>,
        IEventListener<ChooseStoryChoiceEvent>
    {
        protected override void OnOpen()
        {
            base.OnOpen();
        }

        public void OnEvent(OnStoryLineEvent data)
        {
            view.HideChoices();

            if (!view.IsOpen) View.Open<DialogueView>();
            view.DisplayLine(data.line);
        }

        public void OnEvent(OnStoryChoiceEvent data)
        {
            view.DisplayChoices(data.choices);
        }

        public void OnEvent(OnStoryEndEvent data)
        {
            View.Close<DialogueView>();
        }

        public void OnEvent(ChooseStoryChoiceEvent data)
        {
        }
    }
}