using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action<GameObject, GameObject> ProjectileCollided;

    private GameObject _caster;
    private float _speed;
    private Vector3 _travelDirection;

    public void Fire(GameObject caster, Vector3 direction, float speed)
    {
        _caster = caster;
        _speed = speed;

        CalculateTravelDirection(direction);

        GetComponent<Rigidbody>().AddForce(_travelDirection * _speed, ForceMode.Impulse);
    }

    private void CalculateTravelDirection(Vector3 direction)
    {
        _travelDirection = direction;
        _travelDirection.y = 0f;
        _travelDirection.Normalize();
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectileCollided?.Invoke(_caster, other.gameObject);
        Destroy(gameObject);
    }
}
