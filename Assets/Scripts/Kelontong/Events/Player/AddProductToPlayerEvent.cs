
namespace Kelontong.Events
{
    struct AddProductToPlayerEvent
    {
        public string productID;
        public float productQuantity;
        public AddProductToPlayerEvent(string id, float quantity) {
            productID = id;
            productQuantity = quantity;
        }
    }
}