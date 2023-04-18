using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public float myAngle = 0;


    void Start()
    {
        
    }

    void Update()
    {
        PortalCameraController();
    }

    private void PortalCameraController() {
        Vector3 playerOffSetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffSetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);


        if (myAngle == 90 || myAngle == 270) {
            angularDifferenceBetweenPortalRotations -= 90;
        }

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

        if (myAngle == 90 || myAngle == 270) {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y, newCameraDirection.x);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
