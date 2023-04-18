using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;
    public Material material;
    float myAngle;


    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform;

        myRenderPlane.GetComponent<Renderer>().material = Instantiate(material);
        if (myCamera.targetTexture != null) {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.myAngle = myAngle;
    }

    private void Start() {
        myRenderPlane.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }

    void Update()
    {
        
    }
}
