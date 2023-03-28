using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp {
    public KeyColor colorKey;

    public override void Picked() {
        GameManager.Instance.AddKey(colorKey);

        base.Picked();
    }

}


public enum KeyColor {
    Red,
    Green,
    Gold
}