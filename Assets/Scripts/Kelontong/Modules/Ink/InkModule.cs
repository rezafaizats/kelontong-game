using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Ink.Runtime;
using Kelontong.Events.Story;
using Kelontong.ScriptableDatabases;
using Kelontong.StoryData;

namespace Kelontong.Modules.Ink
{
    public class InkModule : BaseModule,
        IEventListener<ContinueStoryEvent>,
        IEventListener<LoadStoryEvent>,
        IEventListener<StartStoryEvent>,
        IEventListener<SetStoryVariableEvent>,
        IEventListener<ChooseStoryChoiceEvent>,
        IQueryProvider<StoryValueQueryResult, StoryValueQuery>
    {
        private const string EVENT = "event";
        
        private Story story;
        private bool storyLoaded = false;
        private bool shouldFireEndStory = false;
        private HashSet<string> registeredVariables = new();

        public void OnEvent(LoadStoryEvent data)
        {
            if (!InkDatabase.TryGet(data.storyId, out var inkData))
                throw new Exception($"Tried to load story but could not find Ink Data with id {data.storyId}");

            if (storyLoaded)
            {
                foreach (var varName in story.variablesState)
                    story.RemoveVariableObserver(OnVariableUpdated, varName);

                registeredVariables.Clear();
            }
            
            story = new Story(inkData.inkFile.ToString());

            StoryEventMetadata.BindEvents(method =>
            {
                object Del(object[] args) => method.Invoke(null, args);
                story.BindExternalFunctionGeneral(method.Name, Del);
            });
            
            foreach (var varName in story.variablesState)
            {
                story.ObserveVariable(varName, OnVariableUpdated);
                if (!registeredVariables.Add(varName)) throw new Exception($"Story has duplicate variable {varName}!");
            }

            storyLoaded = true;
        }

        private void OnVariableUpdated(string varName, object newValue)
        {
            GlobalEvents.Fire(new OnStoryVariableUpdated(varName, newValue));
        }

        public void OnEvent(StartStoryEvent data)
        {
            if (!storyLoaded) throw new Exception("Trying to start story but story is not loaded!");
            
            story.ChoosePathString(data.storyPath);
            if (data.autoContinue) Continue();
        }

        public void OnEvent(SetStoryVariableEvent data)
        {
            if (!storyLoaded) throw new Exception("Trying to set story var but story is not loaded!");

            story.variablesState[data.name] = data.value;
        }

        public StoryValueQueryResult OnQuery(StoryValueQuery data)
        {
            if (!storyLoaded) throw new Exception("Trying to query story but story is not loaded!");

            if (!registeredVariables.Contains(data.name)) return new StoryValueQueryResult(false, null);

            return new StoryValueQueryResult(true, story.variablesState[data.name]);
        }

        public void OnEvent(ContinueStoryEvent data)
        {
            Continue();
        }

        private void Continue()
        {
            if (!storyLoaded) throw new Exception("Trying to continue story but story is not loaded!");

            if (!story.canContinue)
            {
                if (!shouldFireEndStory) return;
                
                GlobalEvents.Fire(new OnStoryEndEvent());
                shouldFireEndStory = false;
                return;
            }

            var nextLine = story.Continue();
            
            var storyLine = new StoryLine(nextLine, story.currentTags);
            GlobalEvents.Fire(new OnStoryLineEvent(storyLine));

            var count = story.currentChoices.Count;
            if (count > 0)
            {
                var nextChoices = new StoryChoice[count];
                for (int i = 0; i < count; i++)
                {
                    var choice = story.currentChoices[i];
                    nextChoices[i] = new StoryChoice(choice.text, choice.tags);
                }
                GlobalEvents.Fire(new OnStoryChoiceEvent(nextChoices));
            }

            shouldFireEndStory = true;
        }

        public void OnEvent(ChooseStoryChoiceEvent data)
        {
            if (!storyLoaded) throw new Exception("Trying to choose story choice but story is not loaded!");

            if (data.index >= story.currentChoices.Count)
                throw new IndexOutOfRangeException($"Story does not have index {data.index}");
            
            story.ChooseChoiceIndex(data.index);
            Continue();
        }
    }
}