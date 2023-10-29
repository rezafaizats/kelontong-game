using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Kelontong.Events;
using UnityEngine;

namespace Kelontong.Modules
{
    public class WorldLoaderModule : BaseModule, IQueryProvider<QueryPresentedProductResult>
    {
        private World.World world;

        public QueryPresentedProductResult OnQuery()
        {
            return new QueryPresentedProductResult(world.GetPresentedProducts());
        }

        protected override Task OnLoad()
        {
            var worldPrefab = PrefabRegistry.Get("World");
            world = Object.Instantiate(worldPrefab).GetComponent<World.World>();
            return base.OnLoad();
        }
    }
}