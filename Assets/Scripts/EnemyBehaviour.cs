using System.Collections;
using System.Collections.Generic;
using ECM.Controllers;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : BaseAgentController
{
    [Header("AI Settings")]
    [SerializeField] GameObject _target;
    [SerializeField] float _health = 100f;
    [SerializeField] float _bulletDamage = 1f;
    [SerializeField] HealthBarUI _healthBarUI;
    [SerializeField] UnityEvent OnDie;

    private float _currentHealth;

    protected override void HandleInput()
    {

    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(_target.transform.position);
        agent.isStopped = false;
        _currentHealth = _health;
        _healthBarUI.SetMaxHealth(_health);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        agent.SetDestination(_target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);

            if(_currentHealth > 0)
            {
                _currentHealth -= _bulletDamage;
                _healthBarUI.UpdateHealth(_currentHealth);
            }
            else
            {
                OnDie?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}