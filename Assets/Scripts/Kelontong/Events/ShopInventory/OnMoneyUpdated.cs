namespace Kelontong.Events.ShopInventory
{
    public struct OnMoneyUpdated
    {
        public int oldValue;
        public int newValue;

        public OnMoneyUpdated(int oldValue, int newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
    }
}