using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.ModulesSystem;

namespace Kelontong.Modules
{
    public class ProductMarketModule : BaseModule
    {
        private Dictionary<string, int> priceCatalogPerUnit;

        protected override Task OnLoad()
        {
            priceCatalogPerUnit = new()
            {

            };  
            
            return base.OnLoad();
        }
    }
}