namespace Kelontong.Events.Minigames.Tepung
{
    public struct OnTepungNumberClearEvent
    {
        public int resetNumber;

        public OnTepungNumberClearEvent(int resetNumber)
        {
            this.resetNumber = resetNumber;
        }
    }
}