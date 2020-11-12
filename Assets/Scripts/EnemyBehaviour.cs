using ECM.Controllers;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : BaseAgentController
{
    private Transform _target;
    private float _currentHealth;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(_target.position);
        agent.isStopped = false;
    }

    public override void Update()
    {
        UpdateRotation();
        Animate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceFromTarget = Vector3.Distance(transform.position, _target.position);

        if (distanceFromTarget > stoppingDistance)
            ChasePlayer();
        else
            AttackTarget();
    }

    private void AttackTarget()
    {
        
    }

    private void ChasePlayer()
    {
        agent.SetDestination(_target.position);
    }

    /*private void OnTriggerEnter(Collider other)
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
    }*/
}