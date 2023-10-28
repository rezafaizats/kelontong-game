using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Kelontong.Modules
{
    public class CameraControlModule : BaseModule
    {
        private CinemachineVirtualCamera virtualCamera;

        protected override Task OnLoad()
        {
            var cameraPrefab = PrefabRegistry.Get("Camera");
            var obj = Object.Instantiate(cameraPrefab);

            virtualCamera = obj.GetComponent<CinemachineVirtualCamera>();
            return base.OnLoad();
        }
    }

}