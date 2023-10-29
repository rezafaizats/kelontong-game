using System;
using System.Collections.Generic;
using Arr.EventsSystem;
using Kelontong.Events.Story;
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
    
    public class CustomerProfile : MonoBehaviour
    {
        [SerializeField] private string startDialoguePath, presentProductDialoguePath;
        [SerializeField] private ProductProfile[] productProfiles;

        public void StartDialogue()
        {
            GlobalEvents.Fire(new StartStoryEvent(startDialoguePath));
        }

        public void StartPresentProductDialogue()
        {
            GlobalEvents.Fire(new StartStoryEvent(presentProductDialoguePath));
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
            throw new NotImplementedException();
        }
    }
}