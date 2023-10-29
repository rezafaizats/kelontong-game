using Arr.EventsSystem;
using Kelontong.Events;
using Kelontong.Events.ShopInventory;

namespace Kelontong
{
    public static class ProductUtility
    {
        public static void TransferFromShopToPlayer(string id, float amount){
            GlobalEvents.Fire(new AddProductToPlayerEvent(id, amount));
            GlobalEvents.Fire(new RemoveProductFromShopEvent(id, -amount));
        }
        
    }
}