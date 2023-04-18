using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    private bool playerIsOverlapping;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerIsOverlapping = false;
        }
    }

    void FixedUpdate()
    {
        Teleportation();
    }

    void Teleportation() {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0) {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;

                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffSet = Quaternion.Euler(0, rotationDiff, 0) * portalToPlayer;
                player.position = receiver.position + positionOffSet;

                playerIsOverlapping = false;
            }

        }
    }
}
