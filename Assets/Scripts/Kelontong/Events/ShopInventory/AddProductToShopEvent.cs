namespace Kelontong.Events.ShopInventory
{
    public struct AddProductToShopEvent
    {
        public string productId;
        public float value;

        public AddProductToShopEvent(string productId, float value)
        {
            this.productId = productId;
            this.value = value;
        }
    }
}