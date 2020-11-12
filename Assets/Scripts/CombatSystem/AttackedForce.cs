using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedForce : MonoBehaviour, IAttackable
{
    [SerializeField] float _forceToAdd;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnAttack(GameObject attacker, Attack attack)
    {
        var forceDirection = transform.position - attacker.transform.position;
        forceDirection.y += 0.5f;
        forceDirection.Normalize();

        _rigidbody.AddForce(forceDirection * _forceToAdd);
    }
}