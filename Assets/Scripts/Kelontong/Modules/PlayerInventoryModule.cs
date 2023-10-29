using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events;

namespace Kelontong.Modules
{
    public class PlayerInventoryModule : BaseModule, IEventListener<AddProductToPlayerEvent>, IEventListener<ClearProductFromPlayerEvent>, IEventListener<QueryProductInPlayerResult>
    {
        private string currentProductID = null;
        private float currentProductQuantity = 0f;

        void IEventListener<QueryProductInPlayerResult>.OnEvent(QueryProductInPlayerResult data)
        {
            
        }

        void IEventListener<ClearProductFromPlayerEvent>.OnEvent(ClearProductFromPlayerEvent data)
        {

        }

        void IEventListener<AddProductToPlayerEvent>.OnEvent(AddProductToPlayerEvent data)
        {
            currentProductID = data.productID;
            currentProductQuantity = data.productQuantity;
        }
    }
}