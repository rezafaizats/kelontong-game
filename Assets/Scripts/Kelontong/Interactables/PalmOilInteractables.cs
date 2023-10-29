using System;
using System.Collections;
using System.Collections.Generic;
using Arr.EventsSystem;
using Kelontong.Events;
using Kelontong.Events.ShopInventory;
using Kelontong.Interactables;
using TMPro;
using UnityEngine;

namespace Kelontong.World
{
    public class PalmOilInteractables : MonoBehaviour, IInteractables
    {
        private const string productId = "minyakGoreng";
        [SerializeField] private TextMeshPro interactText;

        void Start() {
            HideText();
        }

        public void DisplayText()
        {
            interactText.gameObject.SetActive(true);
        }

        public void HideText()
        {
            interactText.gameObject.SetActive(true);
        }

        public void Interact()
        {
            var queryResult =
                GlobalEvents.Query<QueryProductFromShopResult, QueryProductFromShop>(
                    new QueryProductFromShop(productId));
                    
            if(!queryResult.found) throw new Exception("Product doesn't exist!");

            if(queryResult.quantity <= 0) return;

            ProductUtility.TransferFromShopToPlayer(productId, 1);
        }
    }

}