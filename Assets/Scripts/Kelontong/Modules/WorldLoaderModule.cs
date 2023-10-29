using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Kelontong.Events;
using Kelontong.Events.ShopInventory;
using Kelontong.Products;
using UnityEngine;

namespace Kelontong.Modules
{
    public class WorldLoaderModule : BaseModule, 
        IQueryProvider<QueryPresentedProductResult>,
        IQueryProvider<QueryQueueStartTransform>,
        IEventListener<OnDayStartedEvent>
    {
        private World.World world;

        public void OnEvent(OnDayStartedEvent data)
        {
            var queryResult = GlobalEvents.Query<QueryStock>();
            var allProducts = ProductDatabase.GetAll();

            foreach (var product in allProducts)
            {
                world.SetInteractableActive(product.id, 
                    queryResult.stock.ContainsKey(product.id) 
                    && queryResult.stock[product.id] > 0f);
            }
        }

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

        QueryQueueStartTransform IQueryProvider<QueryQueueStartTransform>.OnQuery()
            => new() {transform = world.GetCustomerQueuePosition};
    }
}