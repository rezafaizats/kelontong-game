namespace Kelontong.Events.Minigames.Gula
{
    public struct OnGulaPressedNumberEvent
    {
        public int gulaValue;

        public OnGulaPressedNumberEvent(int gulaValue)
        {
            this.gulaValue = gulaValue;
        }
    }
}