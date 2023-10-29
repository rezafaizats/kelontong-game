using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Player;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules
{
    public class PlayerControllerModule : BaseModule, IEventListener<EventOnViewOpened>, IEventListener<EventOnViewClosed>
    {
        private PlayerController playerController;

        public void OnEvent(EventOnViewOpened data)
        {
            if(data.view is IPreventAction) {
                playerController.SetCanInteract(true);
                playerController.SetCanMove(false);
            }
        }

        public void OnEvent(EventOnViewClosed data)
        {
            if(data.view is IPreventAction) {
                playerController.SetCanInteract(false);
                playerController.SetCanMove(true);
            }
        }

        protected override Task OnLoad()
        {
            var playerPrefab = PrefabRegistry.Get("player");
            var obj = Object.Instantiate(playerPrefab);

            playerController = obj.GetComponent<PlayerController>();
            GlobalEvents.Fire(new CameraSetTargetEvent(playerController.transform));
            
            return base.OnLoad();
        }
    }
}