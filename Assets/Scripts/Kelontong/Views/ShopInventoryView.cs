using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arr.ViewModuleSystem;
using Kelontong.Products;
using Kelontong.Shop;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class ShopInventoryView : View
    {
        [SerializeField] private RectTransform refreshParent;
        [SerializeField] private MMF_Player gainMoneyFeedback;
        [SerializeField] private TextMeshProUGUI moneyText, currentRequestText;
        [SerializeField] private float speed = 5f;

        [SerializeField] private List<ProductPanelElement> productPanelElements;

        private int target;
        private float current;
        private int currentInt;

        public void DisplayRequest(IReadOnlyDictionary<string, float> request)
        {
            if (request.Count <= 0)
            {
                currentRequestText.text = String.Empty;
                return;
            }
            
            currentRequestText.text = "- " + String.Join("\n- ", request.Select(GetRequestString));
            
            Invoke(nameof(DelayedRefresh), 0.05f);
        }

        public void DelayedRefresh()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(refreshParent);
            Canvas.ForceUpdateCanvases();
        }

        private string GetRequestString(KeyValuePair<string, float> arg)
        {
            var data = ProductDatabase.Get(arg.Key);
            return $"{arg.Value}{data.label} of {data.productName}";
        }

        public void DisplayStock(Dictionary<string, float> stock)
        {
            foreach (var panel in productPanelElements)
                panel.gameObject.SetActive(false);

            int i = 0;
            foreach (var s in stock)
            {
                var element = productPanelElements[i];
                element.Display(s.Key, s.Value);
                element.gameObject.SetActive(true);
                i++;
            }
        }

        public void DisplayMoney(int oldValue, int newValue)
        {
            if (newValue > oldValue) gainMoneyFeedback.PlayFeedbacks();
            moneyText.text = newValue.ToString();
        }
    }
}