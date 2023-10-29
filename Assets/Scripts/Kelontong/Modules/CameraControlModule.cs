using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Cinemachine;
using Kelontong.Events;
using Kelontong.World;
using UnityEditor;
using UnityEngine;

namespace Kelontong.Modules
{
    public class CameraControlModule : BaseModule, IEventListener<CameraSetTargetEvent>
    {
        private CameraControl virtualCamera;

        protected override Task OnLoad()
        {
            var cameraPrefab = PrefabRegistry.Get("Camera");
            var obj = Object.Instantiate(cameraPrefab);

            virtualCamera = obj.GetComponent<CameraControl>();
            return base.OnLoad();
        }

        public void SetCameraTarget(Transform target) {
            virtualCamera.SetFollowTarget(target);
        }

        public void OnEvent(CameraSetTargetEvent data)
        {
            throw new System.NotImplementedException();
        }
    }

}