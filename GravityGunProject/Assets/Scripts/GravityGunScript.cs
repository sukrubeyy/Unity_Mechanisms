using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGunScript : MonoBehaviour
{
    [SerializeField] Camera camera;

    //GrabDistance contains difference between raycast and object
    //GrabDistance Raycastin ulaşacağı mesafe aralığıdır

    //throwForce contains the throwing power
    //throwForce ise objeyi fırlatma, atma kuvveti

    //lerpSpeed contains lerp speed of object 
    //lerpSpeed ise objenin yer değiştirme yumuşaklığı

    [SerializeField] float grabDistance = 10f, throwForce = 100f, lerpSpeed = 10f;
    //Holder Object contains the transform that the held object will move.
    //HolderObject tutulan objenin hareket edeceği transformu içerir
    [SerializeField] Transform HolderObject;

    //Rigidbody of the object held
    //Tutulan objenin Rigidbody'si
    Rigidbody grabRB;

    private void Update()
    {
        if(grabRB)
        {
            grabRB.MovePosition(HolderObject.transform.position);
            if(Input.GetMouseButtonDown(0))
            {
                grabRB.isKinematic = false;
                grabRB.AddForce(camera.transform.forward*throwForce,ForceMode.Impulse);
                grabRB = null;
            }
        }

        //When we click key E on keyboard
        //Klavyede E tuşuna bastığımız zaman
        if(Input.GetKeyDown(KeyCode.E))
        {
            //if grabRB is not null and press keycode E this condition drop the object
            //Eğer grabRB boş değilse ve E tuşuna bastıysam bu şart objenin bırakılmasını sağlar.
            if (grabRB)
            {
                //GrabRB isKinematic equls false 
                //because If isKinematic is enabled, Forces, collisions or joints will not affect the rigidbody anymore. 
                grabRB.isKinematic = false;
                grabRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, grabDistance))
                {
                    grabRB = hit.collider.GetComponent<Rigidbody>();
                    if (grabRB)
                    {
                        //if grabRB.isKinematic equls true it's mean we can apply force
                        //Eğer grabRB.isKinematic true değere eşitse bu demek oluyor ki tutulan objeye
                        //kuvvet uygulayabiliriz.
                        grabRB.isKinematic = true;
                    }

                }
            }
        }
       
    }
}
