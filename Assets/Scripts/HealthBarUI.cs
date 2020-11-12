using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{ 
    [SerializeField] Slider _healthSlider;

    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
    }
    public void UpdateHealth(float health)
    {
        if(!_healthSlider.gameObject.activeInHierarchy)
            _healthSlider.gameObject.SetActive(true);

        _healthSlider.value = health;
    }
}
