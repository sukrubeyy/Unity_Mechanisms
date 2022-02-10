using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shaker(.30f, .5f));
        }
    }
    
    IEnumerator Shaker(float time , float force )
    {
        Vector3 position = transform.localPosition;
        position.z = transform.localPosition.z;
        float timeUp = 0f;
        while(timeUp<time)
        {
            float x = Random.Range(-1f, 1f)*force;
            float y = Random.Range(-1f, 1f)*force;
            transform.localPosition = new Vector2(x,y);
            timeUp += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = position;
       
    }
}
