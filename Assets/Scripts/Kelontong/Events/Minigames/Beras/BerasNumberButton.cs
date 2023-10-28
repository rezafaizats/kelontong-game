using System;
using Arr.EventsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Events.Minigames.Beras
{
    public class BerasNumberButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private int number;
        public int Number => number;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            GlobalEvents.Fire(new OnBerasPressedNumberEvent(Number));
        }
    }
}