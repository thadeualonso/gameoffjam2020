using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemBehaviour : MonoBehaviour
{
    [SerializeField] int _chanceToDrop;
    [SerializeField] GameObject _dropItem;

    public void DropItem()
    {
        int rand = Random.Range(0, 101);
        Debug.Log($"Drop random number: {rand}");

        if(rand <= _chanceToDrop)
        {
            Instantiate(_dropItem, transform.position, Quaternion.identity);
        }
    }
}
