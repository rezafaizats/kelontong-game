namespace Kelontong.Events.Story
{
    public struct LoadStoryEvent
    {
        public string storyId;

        public LoadStoryEvent(string storyId)
        {
            this.storyId = storyId;
        }
    }
}