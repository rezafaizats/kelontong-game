using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using UnityEngine;

namespace Kelontong.Modules
{
    public class WorldLoaderModule : BaseModule
    {
        private GameObject world;

        protected override Task OnLoad()
        {
            var worldPrefab = PrefabRegistry.Get("World");
            world = Object.Instantiate(worldPrefab);
            return base.OnLoad();
        }
    }
}