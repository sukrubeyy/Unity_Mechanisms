using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5f;
    SpawnerScript spawnerScript;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnerScript = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        pos = transform.TransformDirection(pos);
        rb.position += pos * Time.deltaTime * speed;
        transform.Rotate(Vector3.up*Input.GetAxisRaw("Mouse X")*2);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 200);
        }
    }

    private void Update()
    {
        if(transform.position.y<-10f && spawnerScript!=null)
        {
            transform.position = spawnerScript.SetTransform();
        }
    }
}
