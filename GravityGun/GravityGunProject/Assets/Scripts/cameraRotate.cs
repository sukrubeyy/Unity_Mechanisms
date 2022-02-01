using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.right * Input.GetAxisRaw("Mouse Y") * -3);
    }
}
