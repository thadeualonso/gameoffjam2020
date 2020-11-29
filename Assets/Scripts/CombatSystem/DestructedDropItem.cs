using System.Collections.Generic;
using UnityEngine;

public class DestructedDropItem : MonoBehaviour, IDestructible
{
    [SerializeField] float _yOffset = 0.5f;
    [SerializeField] List<DropItem> _dropItems;

    public void DropItem()
    {
        int randChance = Random.Range(0, 101);
        
        List<DropItem> possibleDrops = _dropItems.FindAll(i => randChance <= i.ChanceToDrop);

        if(possibleDrops.Count > 0)
        {
            int randIndex = Random.Range(0, possibleDrops.Count);
            var position = new Vector3(
                transform.position.x, 
                _yOffset, 
                transform.position.z);

            Instantiate(possibleDrops[randIndex].ItemToDrop, position, Quaternion.identity);
        }
    }

    public void OnDestruction(GameObject destroyer)
    {
        DropItem();
    }
}

[System.Serializable]
public class DropItem
{
    public int ChanceToDrop;
    public GameObject ItemToDrop;
}