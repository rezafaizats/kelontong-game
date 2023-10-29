using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Kelontong.World
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        public void SetFollowTarget(Transform target) {
            cinemachineVirtualCamera.m_Follow = target;
        }
    }

}