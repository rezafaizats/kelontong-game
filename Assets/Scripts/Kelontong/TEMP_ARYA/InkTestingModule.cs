using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events.Story;
using Kelontong.StoryData;
using UnityEngine;

namespace Kelontong.TEMP_ARYA
{
    public class InkTestingModule : BaseModule, 
        IEventListener<OnStoryChoiceEvent>,
        IEventListener<OnStoryLineEvent>,
        IEventListener<OnStoryEndEvent>
    {
        protected override async Task OnLoad()
        {
            GlobalEvents.Fire(new LoadStoryEvent("testing"));
            GlobalEvents.Fire(new StartStoryEvent("storyPath"));
            
            UnityEvents.onUpdate += OnUpdate;
        }

        protected override Task OnUnload()
        {
            UnityEvents.onUpdate -= OnUpdate;

            return base.OnUnload();
        }

        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) GlobalEvents.Fire(new ContinueStoryEvent());
            if (Input.GetKeyDown(KeyCode.Alpha1)) GlobalEvents.Fire(new ChooseStoryChoiceEvent(0));
            if (Input.GetKeyDown(KeyCode.Alpha2)) GlobalEvents.Fire(new ChooseStoryChoiceEvent(1));
            if (Input.GetKeyDown(KeyCode.Alpha3)) GlobalEvents.Fire(new ChooseStoryChoiceEvent(2));
            
            if (Input.GetKeyDown(KeyCode.R)) GlobalEvents.Fire(new StartStoryEvent("testPath"));
            if (Input.GetKeyDown(KeyCode.T))
            {
                var name = StoryUtility.GetVariable<string>("currentName");
                Debug.Log(name);
            }

        }

        public void OnEvent(OnStoryChoiceEvent data)
        {
            Debug.Log("CHOICES!");
            foreach (var choice in data.choices)
            {
                Debug.Log(choice.Text);
            }
        }

        public void OnEvent(OnStoryLineEvent data)
        {
            if (data.line.TryGetSpeaker(out string speaker)) Debug.Log($"Speaker: {speaker}");
            Debug.Log(data.line.Text);
        }

        public void OnEvent(OnStoryEndEvent data)
        {
            Debug.Log("END OF STORY!");
        }
    }
}