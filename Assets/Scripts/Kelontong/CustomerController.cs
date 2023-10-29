using System.Collections;
using UnityEngine;

namespace Kelontong
{
    public class CustomerController : MonoBehaviour
    {
        private float speed = 0.1f;
        private Vector3 target;
        private Vector3 offset;

        private Coroutine moveCoroutine = null;

        private bool shouldBeDestroyed = false;
        public void SetNextPoint(Vector3 nextPoint, float delay, bool destroy = false)
        {
            shouldBeDestroyed = destroy;
            speed = Random.Range(0.05f, 0.3f);
            var randX = Random.Range(-0.8f, 0.8f);
            var randZ = Random.Range(-0.2f, 0.2f);
            offset = new Vector3(randX, 0f, randZ);

            target = nextPoint + offset;
            
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveToNextPoint(delay));
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
            
            if (shouldBeDestroyed) Destroy(gameObject);
        }
    }
}