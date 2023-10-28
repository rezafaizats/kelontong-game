using System.Collections.Generic;
using Kelontong.StoryData;

namespace Kelontong.Events.Story
{
    public struct OnStoryLineEvent
    {
        public readonly StoryLine line;

        public OnStoryLineEvent(StoryLine line)
        {
            this.line = line;
        }
    }
}