using System;
using System.Collections.Generic;
using Arr.EventsSystem;
using Kelontong.Events;
using Kelontong.Events.Story;
using Kelontong.Interactables;
using Kelontong.Products;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kelontong.Customer
{
    [Serializable]
    public struct ProductProfile
    {
        public string id;
        public float[] quantityPossibilities;
        public float normalizedMarketValueBias;
    }
    
    public class CustomerProfile : MonoBehaviour, IInteractables
    {
        [SerializeField] private TextMeshPro interactText;

        [SerializeField] private string startDialoguePath, presentProductDialoguePath;
        [SerializeField] private ProductProfile[] productProfiles;
        

        void Start() {
            HideText();
        }

        private string GetDayPath(string path)
        {
            if (!path.Contains("{day}")) return path;
            var day = GlobalEvents.Query<QueryDay>().day;
            return path.Replace("{day}", day.ToString());
        }

        public void StartDialogue()
        {
            GlobalEvents.Fire(new StartStoryEvent(GetDayPath(startDialoguePath)));
        }

        public void StartPresentProductDialogue()
        {
            GlobalEvents.Fire(new StartStoryEvent(GetDayPath(presentProductDialoguePath)));
        }

        public Dictionary<string, float> GenerateProductRequest()
        {
            var dict = new Dictionary<string, float>();

            foreach (var profile in productProfiles)
            {
                var randQuantity = profile.quantityPossibilities[Random.Range(0, profile.quantityPossibilities.Length)];
                dict[profile.id] = randQuantity;
            }

            return dict;
        }

        public Dictionary<string, int> GenerateExpectedPricing()
        {
            var dict = new Dictionary<string, int>();

            foreach (var product in productProfiles)
            {
                var data = ProductDatabase.Get(product.id);
                var day = GlobalEvents.Query<QueryDay>().day;
                var value = Mathf.RoundToInt(data.GetPrice(day) * product.normalizedMarketValueBias);
                dict[product.id] = value;
            }

            return dict;
        }


        public void DisplayText()
        {
            interactText.gameObject.SetActive(true);
        }

        public void HideText()
        {
            interactText.gameObject.SetActive(false);
        }

        public void Interact()
        {
            //Interact
            StartDialogue();
        }
    }
}