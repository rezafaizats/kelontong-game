namespace Kelontong.Events.CustomerTransactions
{
    public struct StartSaleEvent {}
    public struct RejectSaleEvent {}
    public struct ConsumeProductsEvent {}
    public struct GenerateProductEvent { public int count; public GenerateProductEvent(int count) { this.count = count; } }
    public struct ResetProductRequestEvent {}
    public struct QueryFulfillmentScore {}
    
    public struct QueryProductRequest { public int index; public QueryProductRequest(int index) { this.index = index; } }

    public class QueryProductRequestResult
    {
        public string productId;
        public float productAmount;
    }

    public struct QueryPrice{}

}