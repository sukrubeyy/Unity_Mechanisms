using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shaker(float time, float force)
    {
        Vector3 originalTransform = transform.localPosition;
        float elapsed = 0;
        while (elapsed < time)
        {
            float x = Random.Range(-1f, 1f) * force;
            float y = Random.Range(-1f, 1f) * force;
            transform.localPosition = new Vector3(x, y, originalTransform.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalTransform;
    }
}
