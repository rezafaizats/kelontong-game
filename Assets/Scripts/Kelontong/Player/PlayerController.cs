using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Calculator;
using Kelontong.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kelontong.Player
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GlobalEvents.Fire(new DisplayNumberCalculatorEvent(){ number = Random.Range(0, 100)});
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                View.Close<CalculatorView>();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                View.Open<CalculatorView>();
            }
        }
    }
}