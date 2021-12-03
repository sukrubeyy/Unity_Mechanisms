using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FallDamage : MonoBehaviour
{
    public Vector3 veloctiy;
    public Rigidbody rb;
    public CameraShaker cameraShakerScript;
    float damage;
    public float jumpForce;
    void Start()
    {
        jumpForce = 320f;
        cameraShakerScript = transform.GetComponentInChildren<CameraShaker>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,jumpForce,0));
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        damage =  collision.relativeVelocity.magnitude;
        Debug.Log(damage/100);
        if(damage>0)
            StartCoroutine(cameraShakerScript.Shaker(.15f,damage/100));
    }
}
