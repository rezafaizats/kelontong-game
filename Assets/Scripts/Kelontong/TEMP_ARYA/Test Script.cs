using System.Collections;
using System.Collections.Generic;
using Arr.ViewModuleSystem;
using Kelontong.Views;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private bool isCalculatorViewOpen = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCalculatorViewOpen)
            {
                Debug.Log("Tertutup");
                View.Close<CalculatorView>();
                isCalculatorViewOpen = false;
            }
            else
            {
                Debug.Log("Terbuka");
                View.Open<CalculatorView>();
                isCalculatorViewOpen = true;
            }
        }

        
    }
}
