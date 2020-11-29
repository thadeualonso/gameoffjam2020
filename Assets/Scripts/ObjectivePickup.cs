using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickup : Pickup
{
    public override void OnPickUp(GameObject other)
    {
        GameManager.Instance.AddObjective();
    }
}