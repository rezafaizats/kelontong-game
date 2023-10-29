using System.Collections.Generic;

namespace Kelontong.Events
{
    public class QueryPresentedProductResult
    {
        public IReadOnlyDictionary<string, float> products;

        public QueryPresentedProductResult(IReadOnlyDictionary<string, float> products)
        {
            this.products = products;
        }
    }
    
    
}