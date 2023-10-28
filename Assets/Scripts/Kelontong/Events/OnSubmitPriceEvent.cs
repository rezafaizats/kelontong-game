namespace Kelontong.Events
{
    public struct OnSubmitPriceEvent
    {
        public int price;

        public OnSubmitPriceEvent(int price)
        {
            this.price = price;
        }
    }
}