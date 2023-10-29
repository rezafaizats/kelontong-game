using System.Collections.Generic;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events;
using Kelontong.Interactables;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Kelontong.World
{
    public class DisplayProduct : MonoBehaviour, IInteractables
    {
        private Dictionary<string, float> products = new Dictionary<string, float>();
        public TextMeshPro interactText;

        public List<DisplayProductItem> displayProductItems = new List<DisplayProductItem>();
        public List<Transform> productPlacementSpawn;
        public Vector2 randomZPlacementOffset;

        void Start() {
            HideText();
        }

        public void AddProductToDisplay(string id, float quantity) {
            products.Add(id, quantity);
            foreach (var item in displayProductItems)
            {
                if(id == item.productID) {
                    var randomPlacement = Random.Range(0, productPlacementSpawn.Count);
                    var placement = productPlacementSpawn[randomPlacement].position;
                    placement.z = Random.Range(randomZPlacementOffset.x, randomZPlacementOffset.y);

                    var displayItem = Instantiate(item.product, placement, Quaternion.identity);
                    displayItem.transform.parent = this.transform;
                }
            }
        }

        public void DisplayText()
        {
            if(products == null || products.Count < 0) return;
            interactText.gameObject.SetActive(true);
        }

        public void HideText()
        {
            if(products == null || products.Count < 0) return;
            interactText.gameObject.SetActive(false);
        }

        public void Interact()
        {
            if(products == null || products.Count < 0) return;
            //Do transaction
        }
    }
}