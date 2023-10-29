using Arr.ModulesSystem;
using Kelontong.Modules;

namespace Kelontong.ModulesLoaders
{
    public class GameLoader : ModulesLoader
    {
        protected override BaseModule[] Modules => new BaseModule[]
        {
            new GameFlowModule()
        };
    }
}