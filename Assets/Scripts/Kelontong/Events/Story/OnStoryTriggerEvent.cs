namespace Kelontong.Events.Story
{
    public struct OnStoryTriggerEvent<T>
    {
        public string eventName;
        public T args;

        public OnStoryTriggerEvent(string eventName, T args)
        {
            this.eventName = eventName;
            this.args = args;
        }
    }
}