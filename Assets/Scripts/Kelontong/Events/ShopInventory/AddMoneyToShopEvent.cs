namespace Kelontong.Events.ShopInventory
{
    public struct AddMoneyToShopEvent
    {
        public int value;

        public AddMoneyToShopEvent(int value)
        {
            this.value = value;
        }
    }
}