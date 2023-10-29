using System.Collections.Generic;
using System.Linq;
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
        public List<DisplayProductElement> productPlacement;

        void Start() {
            HideText();
        }

        public void AddProductToDisplay(string id, float quantity) {
            products.Add(id, quantity);
            var displayItem = productPlacement.First(x => !x.gameObject.activeInHierarchy);
            displayItem.gameObject.SetActive(true);
            displayItem.DisplayItem(id);
        }

        public void ClearPresentedProduct() {
            foreach (var item in productPlacement)
            {
                item.gameObject.SetActive(false);
            }
            products.Clear();
        }

        public Dictionary<string, float> GetPresentedProduct() {
            return products;
        }

        public void DisplayText()
        {
            var queryResult = GlobalEvents.Query<QueryProductInPlayerResult>();
            if(string.IsNullOrEmpty(queryResult.productID)) return;
            
            interactText.gameObject.SetActive(true);
        }

        public void HideText()
        {
            interactText.gameObject.SetActive(false);
        }

        public void Interact()
        {
            var queryResult = GlobalEvents.Query<QueryProductInPlayerResult>();
            if(string.IsNullOrEmpty(queryResult.productID)) return;

            AddProductToDisplay(queryResult.productID, queryResult.productQuantity);
            GlobalEvents.Fire(new ClearProductFromPlayerEvent());
        }
    }
}