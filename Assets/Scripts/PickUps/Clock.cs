using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp {
    public int timeToAdd = 5;

    public override void Picked() {
        GameManager.Instance.AddTime(timeToAdd);

        base.Picked();
    }
}
