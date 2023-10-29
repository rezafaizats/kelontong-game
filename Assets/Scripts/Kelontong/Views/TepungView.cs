using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames.Beras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Kelontong.Views
{
    public class TepungView : View, IPreventInteraction
    {[SerializeField] private Button submitButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Image weightNeedle;
        [SerializeField] private TextMeshProUGUI shopAmountText;

        public override bool ActiveOnSpawn => false;

        private void Awake()
        {
            submitButton.onClick.AddListener(SubmitRiceAmount);
            clearButton.onClick.AddListener(ClearRiceAmount);
        }

        public void DisplayWeight(float amount)
        {
            // weightText.text = angka.ToString("F0");
            var amountToRotation = amount / 1000f;
            amountToRotation *= 270;
            var localRotation = Quaternion.Euler(0f, 0f, -amountToRotation);
            weightNeedle.transform.localRotation = localRotation;
        }

        public void DisplayShopInventory(float amount) {
            shopAmountText.text = amount.ToString("F0");
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