using System;
using UnityEngine;

namespace Kelontong.Events.Customer
{
    public class CustomerAnimation : MonoBehaviour
    {
        [SerializeField] private CustomerController controller;
        [SerializeField] private Animator animator;
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private static readonly int MovementZ = Animator.StringToHash("DirectionZ");

        private void Update()
        {
            animator.SetBool(IsMoving, controller.CurrentDirection.magnitude > 0f);
            animator.SetFloat(MovementZ, controller.CurrentDirection.z);
        }
    }
}