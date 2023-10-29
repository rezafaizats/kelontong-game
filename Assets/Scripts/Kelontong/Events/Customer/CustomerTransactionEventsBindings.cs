using Arr.EventsSystem;
using Kelontong.Events.ShopInventory;
using Kelontong.StoryData;

namespace Kelontong.Events.CustomerTransactions
{
    public static class CustomerTransaction
    {
        [StoryEvent] public static int GetPlayerMoney() => GlobalEvents.Query<QueryMoneyFromShop>().money;
        [StoryEvent] public static int GetPrice() => GlobalEvents.Query<int, QueryPrice>(new ());
        [StoryEvent] public static void RejectSale() => GlobalEvents.Fire(new RejectSaleEvent());
        [StoryEvent] public static void StartSale() => GlobalEvents.Fire(new StartSaleEvent());
        [StoryEvent] public static void ConsumeProducts() => GlobalEvents.Fire(new ConsumeProductsEvent());
        [StoryEvent] public static void GenerateProductRequest(int count) => GlobalEvents.Fire(new GenerateProductEvent(count));
        [StoryEvent] public static void ResetProductRequest() => GlobalEvents.Fire(new ResetProductRequestEvent());
        [StoryEvent] public static float GetProductRequestAmount(int index) 
            => GlobalEvents.Query<QueryProductRequestResult, QueryProductRequest>(new QueryProductRequest(index)).productAmount;
        [StoryEvent] public static string GetProductRequestName(int index)
            => GlobalEvents.Query<QueryProductRequestResult, QueryProductRequest>(new QueryProductRequest(index)).productId;
        [StoryEvent] public static float GetFulfillmentScore() => GlobalEvents.Query<float, QueryFulfillmentScore>(new ());
    }
}