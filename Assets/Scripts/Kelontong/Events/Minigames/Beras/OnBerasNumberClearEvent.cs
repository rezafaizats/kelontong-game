namespace Kelontong.Events.Minigames.Beras
{
    public struct OnBerasNumberClearEvent
    {
        public int resetNumber;

        public OnBerasNumberClearEvent(int resetNumber)
        {
            this.resetNumber = resetNumber;
        }
    }
}