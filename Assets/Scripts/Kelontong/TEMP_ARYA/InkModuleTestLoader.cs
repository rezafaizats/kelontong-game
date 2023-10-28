using Arr.ModulesSystem;
using Kelontong.Modules.Ink;

namespace Kelontong.TEMP_ARYA
{
    public class InkModuleTestLoader : ModulesLoader
    {
        protected override BaseModule[] Modules => new BaseModule[]
        {
            new InkModule(),
            new InkTestingModule()
        };
    }
}