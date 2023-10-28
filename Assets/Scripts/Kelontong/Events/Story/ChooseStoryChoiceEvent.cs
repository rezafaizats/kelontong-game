namespace Kelontong.Events.Story
{
    public struct ChooseStoryChoiceEvent
    {
        public readonly int index;

        public ChooseStoryChoiceEvent(int index)
        {
            this.index = index;
        }
    }
}