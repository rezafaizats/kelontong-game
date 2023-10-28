using System.Collections;
using System.Collections.Generic;
using Arr.EventsSystem;
using Kelontong.Events.Minigames;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Kelontong.Minigames
{
    public class Egg : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Rigidbody eggRB;
        [SerializeField] private Vector3 onHoldOffset;
        [SerializeField] private float eggWeight;
        [SerializeField] private Vector2 eggWeightAvg = new Vector2(200f, 300f);

        private bool isHolding = false;

        void Start() {
            eggRB = GetComponent<Rigidbody>();
            eggWeight = Random.Range(eggWeightAvg.x, eggWeightAvg.y);
            transform.localScale = Vector3.one * eggWeight / ((eggWeightAvg.x + eggWeightAvg.y) / 2);
        }

        void OnTriggerEnter(UnityEngine.Collider other)
        {
            if(other.transform.TryGetComponent<EggTrigger>(out var container)) {
                GlobalEvents.Fire(new OnEggAdded(eggWeight, 1));
            }
        }

        void OnTriggerExit(UnityEngine.Collider other)
        {
            if(other.transform.TryGetComponent<EggTrigger>(out var container)) {
                GlobalEvents.Fire(new OnEggRemoved(eggWeight, -1));
            }
        }

        void FixedUpdate() {
            if(!isHolding) return;

            var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f;
            worldPos += onHoldOffset;
            eggRB.position = -worldPos;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHolding = false;
        }
    }

}