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
        [SerializeField] private float playerMovementSpeed;
        [SerializeField] private Rigidbody playerRigidBody;
        
        
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, 0, verticalInput * playerMovementSpeed);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
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