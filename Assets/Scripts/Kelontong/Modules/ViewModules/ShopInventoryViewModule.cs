using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules.ViewModules
{
    public class ShopInventoryViewModule : ViewModule<ShopInventoryView>,
        IEventListener<OnMoneyUpdated>,
        IEventListener<OnRequestUpdated>
    {
        protected override async Task OnLoad()
        {
            await base.OnLoad();

            var query = GlobalEvents.Query<QueryStock>();
            view.DisplayStock(query.stock);

            var money = GlobalEvents.Query<QueryMoneyFromShop>();
            view.DisplayMoney(money.money);
        }

        public void OnEvent(OnMoneyUpdated data)
        {
            view.DisplayMoney(data.newValue);
        }

        public void OnEvent(OnRequestUpdated data)
        {
            view.DisplayRequest(data.request);
        }
    }
}