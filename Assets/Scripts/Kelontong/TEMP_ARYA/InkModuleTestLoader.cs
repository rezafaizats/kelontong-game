using Arr.MiscModules;
using Arr.ModulesSystem;
using Kelontong.Modules;
using Kelontong.Modules.Ink;
using Kelontong.Modules.ViewModules;

namespace Kelontong.TEMP_ARYA
{
    public class InkModuleTestLoader : ModulesLoader
    {
        protected override BaseModule[] Modules => new BaseModule[]
        {
            /*new ShopInventoryModule(),
            new InkModule(),
            new InkTestingModule(),
            new DialogueViewModule(),
            new UnityEventSystemModule()*/
            new CustomerQueueModule()
        };
    }
}