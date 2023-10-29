using System.Threading.Tasks;
using Arr.EventsSystem;
using Arr.ModulesSystem;
using Kelontong.Events;
using Kelontong.ScriptableDatabases;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Kelontong.Modules
{
    public class BGMModule : BaseModule, IEventListener<OnBGMEvent>
    {
        private AudioSource audioSource;

        protected override async Task OnLoad()
        {
            GameObject newGameObject = new GameObject("AudioSource");
            audioSource = newGameObject.AddComponent<AudioSource>();
        }
        
        public void OnEvent(OnBGMEvent data)
        {
            BGMData bgmData = BGMDatabase.Get(data.bgmId);
            bgmData.clip = audioSource.clip;
            audioSource.Play();
        }
    }
}