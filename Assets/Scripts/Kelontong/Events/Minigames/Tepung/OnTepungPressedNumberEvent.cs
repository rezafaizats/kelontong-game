namespace Kelontong.Events.Minigames.Tepung
{
    public struct OnTepungPressedNumberEvent
    {
        public int tepungValue;

        public OnTepungPressedNumberEvent(int tepungValue)
        {
            this.tepungValue = tepungValue;
        }
    }
}