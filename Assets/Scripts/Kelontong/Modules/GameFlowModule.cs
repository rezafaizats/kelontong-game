using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.MiscModules;
using Arr.ModulesSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Kelontong.Minigames;
using Kelontong.Modules.Ink;
using Kelontong.Modules.ViewModules;
using Kelontong.Views;
using UnityEngine;

namespace Kelontong.Modules
{
    public class GameFlowModule : BaseModule, IEventListener<OnIntroEndEvent>
    {
        private ModulesHandler coreHandler, introHandler, gameHandler, outroHandler;

        private TaskCompletionSource<bool> introDone = new();

        private BaseModule[] coreModules = new BaseModule[]
        {
            new UnityEventSystemModule(),
            new InkModule(),
            new DayOfTimeModule(),
            new ShopInventoryModule(),
            new FadeViewModule(),
        };
        
        private BaseModule[] introModules = new BaseModule[]
        {
            new IntroViewModule(),
        };
        
        private BaseModule[] gameModules = new BaseModule[]
        {
            new ShopInventoryViewModule(),
            new WorldLoaderModule(),
            new CameraControlModule(),
            new CustomerQueueModule(),
            new CustomerTransactionModule(),
            new PlayerInventoryModule(),
            new PlayerControllerModule(),
            
            new BerasViewModule(),
            new CalculatorViewModule(),
            new DialogueViewModule(),
            new MinyakTanahViewModule(),
            new TelurViewModule()
        };
        
        private BaseModule[] outroModules = new BaseModule[]
        {
            
        };

        protected override async Task OnLoad()
        {
            coreHandler = new ModulesHandler(coreModules, GlobalEvents.Instance);
            introHandler = new ModulesHandler(introModules, GlobalEvents.Instance);
            gameHandler = new ModulesHandler(gameModules, GlobalEvents.Instance);
            outroHandler = new ModulesHandler(outroModules, GlobalEvents.Instance);

            Debug.Log("STARTING GAME FLOW");
            
            await coreHandler.Start();
            await introHandler.Start();

            await introDone.Task;
            FadeViewModule.FadeIn(3f);

            View.Close<IntroView>();

            FadeViewModule.FadeOut(0.5f);

            await introHandler.Stop();
            await Task.Delay(500);
            await gameHandler.Start();
            FadeViewModule.FadeIn(4f);
            GlobalEvents.Fire(new StartDayEvent());
        }

        protected override async Task OnUnload()
        {
            if (coreHandler != null) await coreHandler.Stop();
            if (introHandler != null) await introHandler.Stop();
            if (gameHandler != null) await gameHandler.Stop();
            if (outroHandler != null) await outroHandler.Stop();
        }

        public void OnEvent(OnIntroEndEvent data)
        {
            introDone.SetResult(true);
        }
    }
}