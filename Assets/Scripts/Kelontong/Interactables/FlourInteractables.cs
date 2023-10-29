using System.Collections;
using System.Collections.Generic;
using Kelontong.Interactables;
using TMPro;
using UnityEngine;

namespace Kelontong.Interactables
{
    public class FlourInteractables : MonoBehaviour, IInteractables
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

        }

        void Start() {
            HideText();
        }
    }
}