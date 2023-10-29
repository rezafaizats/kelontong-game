namespace Kelontong.Events.Minigames.Gula
{
    public struct OnGulaNumberClearEvent
    {
        public int resetNumber;

        public OnGulaNumberClearEvent(int resetNumber)
        {
            this.resetNumber = resetNumber;
        }
    }
}