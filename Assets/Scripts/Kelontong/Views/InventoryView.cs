using System.Collections;
using System.Collections.Generic;
using Arr.ViewModuleSystem;
using Kelontong.Products;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class InventoryView : View
    {
        [SerializeField] private TextMeshProUGUI inventoryText;
        [SerializeField] private Image inventoryIcon;

        public override bool ActiveOnSpawn => false;

        public void DisplayInventory(string id, float amount) {
            var product = ProductDatabase.Get(id);
            inventoryText.text = string.Format("You are carrying {0} : {1}{2}", product.productName, amount, product.label);
            inventoryIcon.sprite = product.icon;
        }


    }

}