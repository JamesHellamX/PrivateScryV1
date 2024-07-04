using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        // Calculate the player's offset from the other portal
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        // Lock the Y position to the portal's Y position
        playerOffsetFromPortal.y = 0;

        // Update the camera's position
        Vector3 newPosition = portal.position + playerOffsetFromPortal;
        newPosition.y = portal.position.y;
        transform.position = newPosition;

        // Calculate the angular difference between the portals' rotations
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        // Apply the rotational difference to the camera's forward direction
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}

