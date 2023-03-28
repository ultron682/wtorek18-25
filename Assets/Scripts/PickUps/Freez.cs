using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Freez : PickUp
{
    public int FreezTime = 10;

    public override void Picked() {
        GameManager.Instance.FreezTime(FreezTime);

        base.Picked();
    }
}
