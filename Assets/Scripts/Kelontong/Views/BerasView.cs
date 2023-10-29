using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames.Beras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class BerasView : View
    {
        [SerializeField] private Button submitButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private TextMeshProUGUI weightText;

        public override bool ActiveOnSpawn => false;

        private void Awake()
        {
            submitButton.onClick.AddListener(SubmitRiceAmount);
            clearButton.onClick.AddListener(ClearRiceAmount);
        }

        public void DisplayWeight(int angka)
        {
            weightText.text = angka.ToString();
        }

        public void ClearRiceAmount()
        {
            GlobalEvents.Fire(new OnBerasNumberClearEvent());
        }

        public void SubmitRiceAmount()
        {
            GlobalEvents.Fire(new OnBerasSubmitEvent());
        }
    }
}