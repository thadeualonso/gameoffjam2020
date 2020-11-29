using ECM.Controllers;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : BaseAgentController
{
    [Header("Attack Settings")]
    [SerializeField] bool _debug;
    [SerializeField] int _defaultDamage = 2;
    [SerializeField] float _attackCooldown = 1f;
    [SerializeField] float _rangeDetection = 10f;
    [SerializeField] LayerMask _playerLayer;
    
    private Transform _target;
    private float _currentHealth;
    private bool _canAttack;
    private float _attackTimer;

    private void Start()
    {
        _attackTimer = 0f;
    }

    public override void Update()
    {
        if(_target == null)
        {
            var targets = Physics.OverlapSphere(transform.position, _rangeDetection, _playerLayer);
            
            if(targets.Length > 0)
            {
                _target = targets[0].transform;
            }
        }

        UpdateRotation();
        Animate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if(_target != null)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, _target.position);

            if (distanceFromTarget > stoppingDistance)
                ChasePlayer();
            else
                AttackTarget();
        }
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

    private void OnDrawGizmos()
    {
        if(_debug)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _rangeDetection);
        }
    }
}