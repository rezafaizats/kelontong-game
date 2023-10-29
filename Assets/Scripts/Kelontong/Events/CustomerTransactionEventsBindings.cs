using System.Collections.Generic;
using Ink.Runtime;
using Kelontong.StoryData;

namespace Kelontong.Events
{
    public class CustomerTransactionEventsBindings
    {
        [StoryEvent] public static int GetPrice() => 0;
        [StoryEvent] public static void RejectSale(){}
        [StoryEvent] public static void StartSale(){}
        [StoryEvent] public static void ConsumeProducts(){}
        [StoryEvent] public static void GenerateProductRequest(int count){}
        [StoryEvent] public static void ResetProductRequest() {}
        [StoryEvent] public static int GetProductRequestAmount(int index) => 0;
        [StoryEvent] public static string GetProductRequestName(int index) => "gula";
        [StoryEvent] public static float GetFulfillmentScore() => 1f;
    }
}