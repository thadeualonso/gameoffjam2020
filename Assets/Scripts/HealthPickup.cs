using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] float _gainAmount;

    public override void OnPickUp(GameObject other)
    {
        other.GetComponent<HealthSystem>().GainHealth(_gainAmount);
    }
}