using System.Collections;
using System.Collections.Generic;
using Arr.ViewModuleSystem;
using Kelontong.Interactables;
using Kelontong.Views;
using TMPro;
using UnityEngine;

public class CalculatorInteractables : MonoBehaviour, IInteractables
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
        View.Open<CalculatorView>();
    }

    void Start() {
        HideText();
    }
}
