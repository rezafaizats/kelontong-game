using Kelontong.Products;

namespace Kelontong.Events.ShopInventory
{
    public struct QueryProductFromShop
    {
        public string id;

        public QueryProductFromShop(string id)
        {
            this.id = id;
        }
    }
    
    public class QueryProductFromShopResult
    {
        public readonly bool found;
        public readonly float quantity;
        public readonly ProductData data;

        public QueryProductFromShopResult(float quantity, ProductData data)
        {
            this.found = true;
            this.quantity = quantity;
            this.data = data;
        }

        public QueryProductFromShopResult()
        {
            this.found = false;
        }
    }
}