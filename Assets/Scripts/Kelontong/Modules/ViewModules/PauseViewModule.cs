using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.PrefabRegistrySystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Events.ShopInventory;
using Kelontong.Views;

namespace Kelontong.Modules
{
    public class PauseViewModule : ViewModule<PauseView>, IEventListener<SetResumeGameEvent>
    {
        protected override Task OnLoad()
        {
            return base.OnLoad();
        }
        public void OnEvent(SetResumeGameEvent data)
        {
            view.Close();
        }
    }
}