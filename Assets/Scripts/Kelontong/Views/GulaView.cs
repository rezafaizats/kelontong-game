using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Minigames.Beras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class GulaView : View, IPreventAction
    {[SerializeField] private Button submitButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Image weightNeedle;
        [SerializeField] private TextMeshProUGUI shopAmountText;

        [SerializeField] private Image topWeightContainer;
        [SerializeField] private Sprite noneAmount;
        [SerializeField] private Sprite fewAmount;
        [SerializeField] private Sprite someAmount;
        [SerializeField] private Sprite lotsAmount;

        public override bool ActiveOnSpawn => false;

        private void Awake()
        {
            submitButton.onClick.AddListener(SubmitRiceAmount);
            clearButton.onClick.AddListener(ClearRiceAmount);
            
            noneAmount = topWeightContainer.sprite;
        }

        public void DisplayWeight(float amount)
        {
            // weightText.text = angka.ToString("F0");
            var amountToRotation = amount / 1000f;
            amountToRotation *= 270;
            var localRotation = Quaternion.Euler(0f, 0f, -amountToRotation);
            weightNeedle.transform.localRotation = localRotation;

            if(amount > 100 && amount < 250) {
                topWeightContainer.sprite = fewAmount;
            }
            else if(amount >= 250 && amount < 500) {
                topWeightContainer.sprite = someAmount;
            }
            else if(amount >= 500){
                topWeightContainer.sprite = lotsAmount;
            } 
            else
            {
                topWeightContainer.sprite = noneAmount;
            }
        }

        public void DisplayShopInventory(float amount) {
            shopAmountText.text = amount.ToString("F0") + "g";
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