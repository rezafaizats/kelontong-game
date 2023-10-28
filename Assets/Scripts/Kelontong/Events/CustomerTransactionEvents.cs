namespace Kelontong.Events.CustomerTransaction
{
    /*EXTERNAL StartSale()
    EXTERNAL RejectSale()
    EXTERNAL ConsumeProducts()
    EXTERNAL GenerateProductRequest(count)
    EXTERNAL ResetProductRequest()
    EXTERNAL GetProductRequestAmount(index)
    EXTERNAL GetProductRequestName(index)
    EXTERNAL GetFulfillmentScore()*/

    public struct StartSaleEvent {}
    public struct RejectSaleEvent {}
    public struct ConsumeProductsEvent {}
    public struct GenerateProductEvent {}
    public struct ResetProductEvent {}
    public struct QueryProductRequest {}
}