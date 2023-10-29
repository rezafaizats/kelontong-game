using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arr;
using Arr.ModulesSystem;
using Arr.PrefabRegistrySystem;
using UnityEngine;

namespace Kelontong.Modules
{
    public class CustomerQueueModule : BaseModule
    {
        private Queue<CustomerController> queue = new();

        private Vector3 queueStart= new(0,0,0);
        private Vector3 queueDirection = new(0,0,-1);
        private Vector3 spawnPoint = new(0, 0, -20f);
        private float queueDistance = 1f;

        private float spawnTimer = 3f;
        private float lastSpawnTime = 0;

        protected override Task OnLoad()
        {
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
            if (Input.GetKeyDown(KeyCode.Space)) DequeueCustomer();
            
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
            point.x = Random.Range(-8f, 8f);
            point.y /= 2f;
            controller.SetNextPoint(point, 0f, true);

            int index = 0;
            foreach (var q in queue)
            {
                q.SetNextPoint(queueStart + (queueDirection * index), index * Random.Range(0.1f, 0.15f) + 0.2f);
                index++;
            }
        }

        private void SpawnCustomer()
        {
            var prefab = PrefabRegistry.Get("customer");
            var obj = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
            var controller = obj.GetComponent<CustomerController>();

            queue.Enqueue(controller);

            var target = queueStart + (queueDirection * queue.Count);
            controller.SetNextPoint(target, 0f);
        }
    }
}