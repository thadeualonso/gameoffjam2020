using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action<GameObject, GameObject> ProjectileCollided;

    private GameObject _caster;
    private float _speed;
    private Vector3 _travelDirection;
    private float _distanceTravelled;

    public void Fire(GameObject caster, Vector3 direction, float speed)
    {
        _caster = caster;
        _speed = speed;

        CalculateTravelDirection(direction);

        _distanceTravelled = 0f;
    }

    private void CalculateTravelDirection(Vector3 direction)
    {
        _travelDirection = direction;
        _travelDirection.y = 0f;
        _travelDirection.Normalize();
    }

    private void Update()
    {
        float distanceToTravel = _speed * Time.deltaTime;

        transform.Translate(_travelDirection * distanceToTravel);

        _distanceTravelled += distanceToTravel;
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectileCollided?.Invoke(_caster, other.gameObject);
        Destroy(gameObject);
    }
}
