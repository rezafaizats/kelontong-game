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
    class TelurView : View
    {
        [SerializeField] private TextMeshPro scaleText;
        [SerializeField] private Egg eggPrefabs;

        [SerializeField] private List<Transform> eggSpawnPositions;

        public override bool ActiveOnSpawn => false;

        public void DisplayWeight(float weight) {
            scaleText.text = weight.ToString("F0") + "g";
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