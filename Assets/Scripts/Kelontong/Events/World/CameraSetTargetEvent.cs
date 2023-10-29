using UnityEngine;

namespace Kelontong.Events
{
    public struct CameraSetTargetEvent
    {
        public Transform target;

        public CameraSetTargetEvent(Transform target) {
            this.target = target;
        }
    }
}