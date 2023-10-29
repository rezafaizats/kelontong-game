using System.Collections;
using System.Collections.Generic;
using Arr.ViewModuleSystem;
using Kelontong.Views;
using TMPro;
using UnityEngine;

namespace Kelontong.Interactables
{
    public class EggInteractables : MonoBehaviour, IInteractables
    {
        public TextMeshPro interactText;

        public void DisplayText()
        {
            interactText.gameObject.SetActive(true);
        }

        public void HideText()
        {
            interactText.gameObject.SetActive(false);
        }

        public void Interact()
        {
            View.Open<TelurView>();
        }

        void Start() {
            HideText();
        }
    }

}