using System;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Calculator;
using Kelontong.Interactables;
using Kelontong.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kelontong.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerMovementSpeed;
        [SerializeField] private Rigidbody playerRigidBody;


        private IInteractables currentInteractables = null;

        private bool canInteract = true;
        private bool canMove = true;
        
        
        private void Update()
        {
            
            
            if (Input.GetKeyDown(KeyCode.E) && currentInteractables != null)
            {
                Debug.Log($"INTERACT ATTEMPT, can interact? {canInteract}");
                if (!canInteract) Debug.Log("TRYING TO INTERACT WHILE NOT BEING ABLE TO MOVE");
                else currentInteractables.Interact();
            }

            if (!canMove)
            {
                playerRigidBody.velocity = Vector3.zero;
                return;
            }
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, 0, verticalInput * playerMovementSpeed);

            // if (Input.GetKeyDown(KeyCode.P))
            // {
            //     View.Close<CalculatorView>();
            // }

            // if (Input.GetKeyDown(KeyCode.O))
            // {
            //     View.Open<CalculatorView>();
            // }
        }

        void OnCollisionEnter(Collision collision) {
            if(collision.transform.TryGetComponent<IInteractables>(out var interactables)) {
                interactables.DisplayText();
                currentInteractables = interactables;
            }
        }

        void OnTriggerEnter(Collider other) {
            if(other.transform.TryGetComponent<IInteractables>(out var interactables)) {
                interactables.DisplayText();
                currentInteractables = interactables;
                Debug.Log($"GOT INTERACTABLE {other.name}");
            }
        }

        void OnTriggerExit(Collider other) {
            if(other.transform.TryGetComponent<IInteractables>(out var interactables)) {
                interactables.HideText();
                currentInteractables = interactables;
            }
        }

        void OnCollisionExit(Collision collision) {
            if(collision.transform.TryGetComponent<IInteractables>(out var interactables)) {
                interactables.HideText();
                currentInteractables = interactables;
            }
        }

        public void SetCanInteract(bool status) {
            canInteract = status;
        }
        
        public void SetCanMove(bool status) {
            canMove = status;
        }
    }
}