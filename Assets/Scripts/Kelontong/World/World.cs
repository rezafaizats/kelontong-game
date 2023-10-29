using System;
using System.Collections;
using System.Collections.Generic;
using Kelontong.Interactables;
using Kelontong.Modules;
using UnityEngine;

namespace Kelontong.World
{
    public class World : MonoBehaviour
    {
        [SerializeField] private GameObject oilInteractables;
        [SerializeField] private GameObject sugarInteractables;
        [SerializeField] private GameObject riceInteractables;
        [SerializeField] private GameObject flourInteractables;
        [SerializeField] private GameObject eggInteractables;
        [SerializeField] private GameObject palmOilInteractables;

        [SerializeField] private Transform customerSpawnPosition;
        [SerializeField] private Transform customerQueuePosition;

        public Transform GetCustomerSpawnPosition => customerSpawnPosition;
        public Transform GetCustomerQueuePosition => customerQueuePosition;

        private DisplayProduct displayProduct;

        public void SetInteractableActive(string productID, bool active) {
            switch (productID)
            {
                case "minyakGoreng":
                    palmOilInteractables.SetActive(active);
                    break;
                case "minyakTanah":
                    oilInteractables.SetActive(active);
                    break;
                case "tepung":
                    flourInteractables.SetActive(active);
                    break;
                case "telur":
                    eggInteractables.SetActive(active);
                    break;
                case "beras":
                    riceInteractables.SetActive(active);
                    break;
                case "gula":
                    sugarInteractables.SetActive(active);
                    break;
                default:
                    throw new Exception(productID + " doesn't exist!");
            }
        }

        public void DisplayProduct(string id, float quantity) {
            displayProduct.AddProductToDisplay(id, quantity);
        }

        public void ClearPresentedProduct() {
            displayProduct.ClearPresentedProduct();
        }

        public Dictionary<string, float> GetPresentedProducts() {
            return displayProduct.GetPresentedProduct();
        }


    }

}