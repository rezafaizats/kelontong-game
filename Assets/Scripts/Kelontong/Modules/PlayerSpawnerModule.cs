using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Kelontong.Events;
using Kelontong.Player;
using UnityEngine;

namespace Kelontong.Modules
{
    public class PlayerSpawnerModule : BaseModule
    {
        private PlayerController playerController;
        
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