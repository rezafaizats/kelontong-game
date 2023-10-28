using System.Collections.Generic;

namespace Kelontong.Events.ShopInventory
{
    public struct OnShopInventoryUpdated
    {
        public IReadOnlyDictionary<string, float> products;

        public OnShopInventoryUpdated(IReadOnlyDictionary<string, float> products)
        {
            this.products = products;
        }
    }
}