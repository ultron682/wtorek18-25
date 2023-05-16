using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update()
    {
        Rotation();
    }

    public virtual void Picked() {
        Debug.Log("Podnioslem");
        Destroy(this.gameObject);
    }

    public void Rotation() {
        transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0));
    }
}
