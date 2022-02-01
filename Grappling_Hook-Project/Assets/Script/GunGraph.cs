using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGraph : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 grapplePoint;
    public LayerMask grappleLayer;
    public Transform linePos, cameraPos;
    private float maxDistance=100f;
    private SpringJoint joint;
    public Transform player;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            startGrapple();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            stopGrapple();
        }
    }
    private void LateUpdate()
    {
        drawLine();
    }

    void startGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraPos.position,cameraPos.forward,out hit,maxDistance,grappleLayer))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distancePoint = Vector3.Distance(player.position,grapplePoint);

            joint.maxDistance = distancePoint * 0.8f;
            joint.minDistance = distancePoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
        }
    }
    void stopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
        SpringJoint[] all = player.GetComponents<SpringJoint>();
        foreach (var item in all)
        {
            Destroy(item);
        }
    }
    void drawLine()
    {
        if (!joint) return;
        lineRenderer.SetPosition(0,linePos.position);
        lineRenderer.SetPosition(1,grapplePoint);
    }
}
