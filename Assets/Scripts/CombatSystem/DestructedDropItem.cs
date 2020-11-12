using UnityEngine;

public class DestructedDropItem : MonoBehaviour, IDestructible
{
    [SerializeField] int _chanceToDrop;
    [SerializeField] GameObject _dropItem;

    public void DropItem()
    {
        int rand = Random.Range(0, 101);

        if(rand <= _chanceToDrop)
        {
            Instantiate(_dropItem, transform.position, Quaternion.identity);
        }
    }

    public void OnDestruction(GameObject destroyer)
    {
        DropItem();
    }
}