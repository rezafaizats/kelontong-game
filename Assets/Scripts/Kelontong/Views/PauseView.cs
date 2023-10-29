using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class PauseView : View
    {
        [SerializeField] Button resumeButton;
        [SerializeField] Button quitButton;

        public override bool ActiveOnSpawn => false;

        protected override void OnOpen()
        {
            resumeButton.onClick.AddListener(ResumeGame);
            quitButton.onClick.AddListener(QuitGame);
            base.OnOpen();
        }

        protected override void OnClose()
        {
            resumeButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
            base.OnClose();
        }

        public void ResumeGame() {
            GlobalEvents.Fire(new SetResumeGameEvent());
        }

        public void QuitGame() {
            Application.Quit();
        }
    }

}