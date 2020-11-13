using ECM.Controllers;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : BaseAgentController
{
    [Header("Attack Settings")]
    [SerializeField] int _defaultDamage = 2;
    [SerializeField] float _attackCooldown = 1f;
    
    private Transform _target;
    private float _currentHealth;
    private bool _canAttack;
    private float _attackTimer;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(_target.position);
        agent.isStopped = false;
        _attackTimer = 0f;
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
        if(_attackTimer <= 0f)
        {
            DoDamage();
            _attackTimer = _attackCooldown;
        }
        else
        {
            _attackTimer -= Time.deltaTime;
        }
    }

    private void DoDamage()
    {
        Attack attack = new Attack(_defaultDamage, false);

        var targetAttackables = _target.GetComponents(typeof(IAttackable));

        foreach (IAttackable attackable in targetAttackables)
        {
            attackable.OnAttack(gameObject, attack);
        }
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