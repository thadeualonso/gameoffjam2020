using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    [SerializeField] protected HealthBarUI _healthBarUI;

    protected float _currentHealth;
    protected float _dropTimer;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _healthBarUI.SetMaxHealth(_maxHealth);
    }

    protected virtual void Update()
    {
        if(_currentHealth > 0)
            _healthBarUI.UpdateHealth(_currentHealth);
    }

    public void TakeDamage(float amount)
    {
        if(_currentHealth > 0f)
        {
            _currentHealth -= amount;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void GainHealth(float gainAmount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth += gainAmount;
        }

        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}