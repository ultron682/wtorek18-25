using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;

    public bool open = false;
    public int speed = 5;


    void Start()
    {
        door.position = closePosition.position;
    }

    void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition.position) > 0.001F) {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * speed);
        }
        else if (open == false && Vector3.Distance(door.position, closePosition.position) > 0.001F) {
            door.position = Vector3.MoveTowards(door.position, closePosition.position, Time.deltaTime * speed);
        }
    }

    public void OpenClose() {
        open = !open;
    }
}
