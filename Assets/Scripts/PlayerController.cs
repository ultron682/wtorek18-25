using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float speed = 12f;
    [SerializeField]
    float startSpeed = 12f;
    Vector3 velocity;  // posluzy do wyliczania predkosci w dol
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;



    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask)) {
            string tagRaycast = hit.collider.gameObject.tag;

            switch (tagRaycast) {
                case "LowSpeed":
                    speed = startSpeed * 0.5f;
                    break;
                case "HighSpeed":
                    speed = startSpeed * 2f;
                    break;
                default:
                    speed = startSpeed;
                    break;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * Time.deltaTime * speed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "PickUp") {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
