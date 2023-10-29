using System;
using UnityEngine;

namespace Kelontong.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            playerAnimator.SetFloat("DirectionX", horizontalInput);
            playerAnimator.SetFloat("DirectionZ", verticalInput);

            bool isCharacterMoving = Mathf.Abs(horizontalInput) > 0.1f || Math.Abs(verticalInput) > 0.1f;
            playerAnimator.SetBool("isMoving", isCharacterMoving);
        }
    }
}