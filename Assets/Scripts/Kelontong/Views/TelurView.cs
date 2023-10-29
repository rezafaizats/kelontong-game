using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames;
using Kelontong.Minigames;
using TMPro;
using UnityEngine;

namespace Kelontong.Views
{
    class TelurView : View, IPreventAction
    {
        [SerializeField] private SpriteRenderer scaleNeedle;
        [SerializeField] private Egg eggPrefabs;

        [SerializeField] private List<Transform> eggSpawnPositions;

        public override bool ActiveOnSpawn => false;

        protected override void OnOpen()
        {
            Debug.Log("TESTING");
            base.OnOpen();
        }

        public void DisplayWeight(float weight) {
            var weightToRotation = weight / 1000f;
            weightToRotation *= 270;
            var localRotation = Quaternion.Euler(0f, 0f, -weightToRotation);
            scaleNeedle.transform.localRotation = localRotation;
        }

        public void DisplayEgg(int totalEgg) {
            foreach (var item in eggSpawnPositions)
            {
                if(totalEgg <= 0)
                    break;

                var egg = Instantiate(eggPrefabs, item.position, Quaternion.identity);
                egg.transform.parent = this.transform;
            }
        }
        public void Submit() {
            GlobalEvents.Fire(new OnTelurSubmitEvent());
        }
    }
}