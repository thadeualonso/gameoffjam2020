using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    [SerializeField] float _dropAmount;
    [SerializeField] float _healthDropRate;
    [SerializeField] HealthBarUI _healthBarUI;

    private float _currentHealth;
    private float _dropTimer;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _dropTimer = _healthDropRate;
        _healthBarUI.SetMaxHealth(_maxHealth);
    }

    public void LoseHealth(float amount)
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

    public void GainHealth(float gainAmount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth += gainAmount;
        }

        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    private void Update()
    {
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

            _healthBarUI.UpdateHealth(_currentHealth);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
