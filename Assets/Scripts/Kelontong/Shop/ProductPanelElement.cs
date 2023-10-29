using Arr.EventsSystem;
using Kelontong.Events;
using Kelontong.Products;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Shop
{
    public class ProductPanelElement : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI nameText, stockText, marketPriceText;

        public void Display(string id, float quantity)
        {
            var data = ProductDatabase.Get(id);

            icon.sprite = data.icon;
            nameText.text = data.productName;
            stockText.text = $"In Stock: {quantity:F2}{data.label}";
            var day = GlobalEvents.Query<QueryDay>().day;
            marketPriceText.text = $"MARKET PRICE:<br>Rp.{data.GetPrice(day)}/{data.label}";
        }
    }
}