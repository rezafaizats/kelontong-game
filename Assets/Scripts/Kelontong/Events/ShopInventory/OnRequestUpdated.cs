using System.Collections.Generic;

namespace Kelontong.Events.ShopInventory
{
    public struct OnRequestUpdated
    {
        public IReadOnlyDictionary<string, float> request;

        public OnRequestUpdated(IReadOnlyDictionary<string, float> request)
        {
            this.request = request;
        }
    }
}