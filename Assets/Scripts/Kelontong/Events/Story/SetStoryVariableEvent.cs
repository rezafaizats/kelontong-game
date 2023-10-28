namespace Kelontong.Events.Story
{
    public struct SetStoryVariableEvent
    {
        public string name;
        public object value;

        public SetStoryVariableEvent(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}