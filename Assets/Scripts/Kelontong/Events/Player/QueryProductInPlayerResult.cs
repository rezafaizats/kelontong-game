namespace Kelontong.Events
{
    struct QueryProductInPlayerResult
    {
        public string productID;
        public float productQuantity;

        public QueryProductInPlayerResult(string id, float quantity) {
            productID = id;
            productQuantity = quantity;
        }
    }
}