using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp {
    public KeyColor colorKey;
    public Material red;
    public Material green;
    public Material gold;


    public override void Picked() {
        GameManager.Instance.AddKey(colorKey);

        base.Picked();
    }

    private void Start()
    {
        SetMyColor();
    }

    void SetMyColor()
    {
        switch (colorKey)
        {
            case KeyColor.Red:
                GetComponentInChildren<MeshRenderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponentInChildren<MeshRenderer>().material = green;
                break;
            case KeyColor.Gold:
                GetComponentInChildren<MeshRenderer>().material = gold;
                break;
        }
    }

}


public enum KeyColor {
    Red,
    Green,
    Gold
}