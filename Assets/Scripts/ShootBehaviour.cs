using UnityEngine;
using UnityEngine.Events;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPoint;
    [SerializeField] float _shootForce;
    [SerializeField] float _fireRate = 0.25f;
    [SerializeField] int _defaultDamage = 1;
    [SerializeField] UnityEvent OnShoot;

    private bool _canShoot;
    private float _shootTimer;

    void Update()
    {
        if(_shootTimer <= 0f)
        {
            _canShoot = true;
            _shootTimer = _fireRate;
        }
        else
        {
            _canShoot = false;
            _shootTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            Projectile projectile = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.Fire(gameObject, transform.forward, _shootForce);
            projectile.ProjectileCollided += OnProjectileCollided;
            OnShoot?.Invoke();
        }
    }

    private void OnProjectileCollided(GameObject caster, GameObject target)
    {
        if (caster == null || target == null)
            return;

        Attack attack = new Attack(_defaultDamage, false);

        var targetAttackables = target.GetComponents(typeof(IAttackable));

        foreach (IAttackable attackable in targetAttackables)
        {
            attackable.OnAttack(caster, attack);
        }
    }
}
