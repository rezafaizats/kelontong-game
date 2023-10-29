namespace Kelontong.Events.ShopInventory
{
    public struct RemoveProductFromShopEvent
    {
        public string productId;
        public float quantity;
        public RemoveProductFromShopEvent(string id, float quantity) {
            productId = id;
            this.quantity = quantity;
        }
    }
}