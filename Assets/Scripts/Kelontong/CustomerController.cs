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
            var randX = Random.Range(-2f, 2f);
            var randZ = Random.Range(-0.2f, 0.2f);
            offset = new Vector3(randX, 0f, randZ);

            target = nextPoint + offset;
            
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveToNextPoint(delay));
        }

        public void Leave(Vector3 point)
        {
            Debug.Log("LEAVING", gameObject);
            speed = Random.Range(1f, 2f);
            target = point;

            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            StartCoroutine(LeaveCoroutine());
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
            var startPos = transform.position;
            float journeyLength = Vector3.Distance(startPos, target);
            float startTime = Time.time;

            float distanceCovered = 0;
            while (distanceCovered < journeyLength)
            {
                float fractionOfJourney = (Time.time - startTime) * speed / journeyLength;
                float smoothStepValue = Mathf.SmoothStep(0, 1, fractionOfJourney);

                var targetPos = Vector3.Lerp(startPos, target, smoothStepValue);

                targetPos.x = Mathf.Lerp(startPos.x, target.x, arcCurve.Evaluate(smoothStepValue));

                transform.position = targetPos;
                Debug.Log($"SmoothStepVal: {smoothStepValue}, target {target}, current pos {targetPos}, start pos {startPos}");
                
                distanceCovered = (Time.time - startTime) * speed;
                yield return null;
            }

            DestroyImmediate(gameObject);
        }
    }
}