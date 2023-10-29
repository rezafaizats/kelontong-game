using System.Collections;
using UnityEngine;

namespace Kelontong
{
    public class CustomerController : MonoBehaviour
    {
        [SerializeField] private AnimationCurve arcCurve;
        private float speed = 0.1f;
        private Vector3 target;
        private Vector3 offset;

        private Coroutine moveCoroutine = null;

        public void SetNextPoint(Vector3 nextPoint, float delay)
        {
            speed = Random.Range(0.05f, 0.3f);
            var randX = Random.Range(-0.8f, 0.8f);
            var randZ = Random.Range(-0.2f, 0.2f);
            offset = new Vector3(randX, 0f, randZ);

            target = nextPoint + offset;
            
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveToNextPoint(delay));
        }

        public void Leave(Vector3 point)
        {
            
        }

        private IEnumerator MoveToNextPoint(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            float journeyLength = Vector3.Distance(transform.position, target);
            float startTime = Time.time;

            float distanceCovered = 0;
            while (distanceCovered < journeyLength)
            {
                float fractionOfJourney = (Time.time - startTime) * speed / journeyLength;
                float smoothStepValue = Mathf.SmoothStep(0, 1, fractionOfJourney);

                transform.position = Vector3.Lerp(transform.position, target, smoothStepValue);
            
                distanceCovered = (Time.time - startTime) * speed;
                yield return null;
            }
        }
        
        private IEnumerator LeaveCoroutine()
        {
            Vector3 startPoint = transform.position;
            float journeyLength = Vector3.Distance(startPoint, target);
            float startTime = Time.time;

            float distanceCovered = 0;
            while (distanceCovered < journeyLength)
            {
                float fractionOfJourney = distanceCovered / journeyLength;
            
                Vector3 nextPosition = Vector3.Lerp(startPoint, target, fractionOfJourney);
            
                // Adjust the Y position based on the arcCurve
                nextPosition.y += arcCurve.Evaluate(fractionOfJourney) * journeyLength;

                transform.position = nextPosition;
            
                distanceCovered = (Time.time - startTime) * speed;
                yield return null;
            }

            DestroyImmediate(gameObject);
        }
    }
}