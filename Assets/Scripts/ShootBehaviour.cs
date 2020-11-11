using UnityEngine;
using UnityEngine.Events;

public class ShootBehaviour : MonoBehaviour
{

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPoint;
    [SerializeField] float _shootForce;
    [SerializeField] float _fireRate = 0.25f;
    [SerializeField] UnityEvent OnShoot;
    private bool _canShoot;
    private float _shootTimer;

    // Update is called once per frame
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
            var bullet = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shootForce, ForceMode.Impulse);
            OnShoot?.Invoke();
        }
    }
}
