using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnPickUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    public abstract void OnPickUp(GameObject other);
}
