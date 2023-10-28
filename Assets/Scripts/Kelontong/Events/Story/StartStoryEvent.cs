namespace Kelontong.Events.Story
{
    public struct StartStoryEvent
    {
        public string storyPath;
        public bool autoContinue;

        public StartStoryEvent(string storyPath, bool autoContinue = true)
        {
            this.storyPath = storyPath;
            this.autoContinue = autoContinue;
        }
    }
}