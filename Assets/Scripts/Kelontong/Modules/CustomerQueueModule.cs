using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arr;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using Kelontong.Customer;
using Kelontong.Events;
using Kelontong.Events.CustomerTransactions;
using Kelontong.ScriptableDatabases;
using UnityEngine;

namespace Kelontong.Modules
{
    public class CustomerQueueModule : BaseModule,
        IEventListener<OnDayStartedEvent>,
        IEventListener<OnDayEndedEvent>,
        IEventListener<DequeueCustomerEvent>,
        IQueryProvider<CustomerProfile, QueryFrontCustomer>
    {
        private Queue<CustomerController> queue = new();

        private Vector3 queueStart= new(0,0,0);
        private Vector3 queueDirection = new(0,0,-1);
        private Vector3 spawnPoint = new(0, 0, -20f);
        private float queueDistance = 1f;

        private float spawnTimer = 3f;
        private float lastSpawnTime = 0;
        private int maxCustomers = 20;

        private bool shouldSpawn = false;

        private CustomerSpawnPoolData currentData;
        private Queue<GameObject> specialCustomers;

        protected override Task OnLoad()
        {
            var t = GlobalEvents.Query<QueryQueueStartTransform>();
            queueStart = t.transform.position;
            spawnPoint = queueStart + queueDirection * 20f;
            
            
            
            UnityEvents.onUpdate += Update;
            return base.OnLoad();
        }

        protected override Task OnUnload()
        {
            UnityEvents.onUpdate -= Update;
            return base.OnUnload();
        }

        private void Update()
        {
            if (!shouldSpawn) return;
            if (queue.Count >= maxCustomers) return;
            
            var time = Time.time;
            if (time - lastSpawnTime < spawnTimer) return;

            SpawnCustomer();
            lastSpawnTime = time;
        }

        private void DequeueCustomer()
        {
            if (queue.Count <= 0) return;
            var controller = queue.Dequeue();
            var point = spawnPoint;
            point.x = Random.Range(0, 2) > 0 ? -6f : 6f;
            controller.Leave(point);

            int index = 0;
            foreach (var q in queue)
            {
                var delay = index * Random.Range(0.1f, 0.15f) + 0.2f;
                SetCustomerPosition(q, index, delay);
                index++;
            }
        }

        private void SpawnCustomer()
        {
            
            
            /*var obj = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
            var controller = obj.GetComponent<CustomerController>();
            SetCustomerPosition(controller, queue.Count, 0f);

            queue.Enqueue(controller);*/
        }

        private void SetCustomerPosition(CustomerController controller, int index, float delay)
        {
            var target = queueStart + (queueDirection * index);

            if (index == 0) target += queueDirection * -1.5f;
               
            controller.SetNextPoint(target, delay);
        }

        public void OnEvent(DequeueCustomerEvent data)
        {
            DequeueCustomer();
        }

        public CustomerProfile OnQuery(QueryFrontCustomer data)
        {
            var front = queue.Peek();
            var profile = front.GetComponent<CustomerProfile>();
            return profile;
        }

        public void OnEvent(OnDayStartedEvent data)
        {
            shouldSpawn = true;
        }

        public void OnEvent(OnDayEndedEvent data)
        {
            shouldSpawn = false;

            var front = queue.Dequeue();

            foreach (var customer in queue)
            {
                var point = spawnPoint;
                point.x = Random.Range(-6f, 6f);
                customer.Leave(point);
            }

            queue = new Queue<CustomerController>();
            queue.Enqueue(front);
        }
    }
}