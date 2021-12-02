using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FallDamage : MonoBehaviour
{
    public Vector3 veloctiy;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // collision.relativeVelocity.magnitude;   
     
        CameraShaker._Shake = true;
    }
}
