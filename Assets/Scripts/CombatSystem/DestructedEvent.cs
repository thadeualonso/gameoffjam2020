using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructedEvent : MonoBehaviour, IDestructible
{
    public event Action IDied;

    public void OnDestruction(GameObject destroyer)
    {
        IDied?.Invoke();
    }
}
