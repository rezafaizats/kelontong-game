namespace Kelontong.Events.ShopInventory
{
    public struct RemoveMoneyFromShopEvent
    {
        public int value;

        public RemoveMoneyFromShopEvent(int value)
        {
            this.value = value;
        }
    }
}