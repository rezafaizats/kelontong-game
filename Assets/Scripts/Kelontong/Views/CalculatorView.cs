using Arr.ViewModuleSystem;
using TMPro;
using UnityEngine;

namespace Kelontong.Views
{
    public class CalculatorView : View
    {
        [SerializeField] private TextMeshProUGUI calculatorText;

        public void Display(int angka)
        {
            calculatorText.text = angka.ToString();
        }
    }
}
