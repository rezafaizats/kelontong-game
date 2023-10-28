namespace Kelontong.Events.Story
{
    public struct OnStoryVariableUpdated
    {
        public string name;
        public object value;

        public OnStoryVariableUpdated(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}