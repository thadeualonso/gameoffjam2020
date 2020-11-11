using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float _lifeTime = 1f;
    void Start()
    {
        Invoke("DestroyThis", _lifeTime);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
