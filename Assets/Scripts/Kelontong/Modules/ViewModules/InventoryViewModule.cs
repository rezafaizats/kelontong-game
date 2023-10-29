using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Views;

namespace Kelontong.Modules
{
    public class InventoryViewModule : ViewModule<InventoryView>, IEventListener<AddProductToPlayerEvent>, IEventListener<ClearProductFromPlayerEvent>
    {
        void IEventListener<AddProductToPlayerEvent>.OnEvent(AddProductToPlayerEvent data)
        {
            view.Open();
            view.DisplayInventory(data.productID, data.productQuantity);
        }

        void IEventListener<ClearProductFromPlayerEvent>.OnEvent(ClearProductFromPlayerEvent data)
        {
            view.Close();
        }
    }
}