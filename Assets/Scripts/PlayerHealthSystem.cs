using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] float _dropAmount;
    [SerializeField] float _healthDropRate;

    protected override void Start()
    {
        base.Start();
        _dropTimer = _healthDropRate;
    }

    protected override void Update()
    {
        base.Update();

        if(_currentHealth > 0)
        {
            if(_dropTimer <= 0f)
            {
                _currentHealth -= _dropAmount;
                _dropTimer = _healthDropRate;
            }
            else
            {
                _dropTimer -= Time.deltaTime;
            }
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}