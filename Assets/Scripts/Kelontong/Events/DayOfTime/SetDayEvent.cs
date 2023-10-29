namespace Kelontong.Events
{
    public struct SetDayEvent
    {
        public int day;

        public SetDayEvent(int day)
        {
            this.day = day;
        }
    }
}