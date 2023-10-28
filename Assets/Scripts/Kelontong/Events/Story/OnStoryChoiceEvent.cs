using Kelontong.StoryData;

namespace Kelontong.Events.Story
{
    public struct OnStoryChoiceEvent
    {
        public readonly StoryChoice[] choices;

        public OnStoryChoiceEvent(StoryChoice[] choices)
        {
            this.choices = choices;
        }
    }
}