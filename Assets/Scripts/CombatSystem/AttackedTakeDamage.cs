using UnityEngine;

public class AttackedTakeDamage : MonoBehaviour, IAttackable
{
    [SerializeField] HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    public void OnAttack(GameObject attacker, Attack attack)
    {
        _healthSystem.TakeDamage(attack.Damage);

        if(_healthSystem.GetHealth() <= 0)
        {
            var destructibles = GetComponents(typeof(IDestructible));

            foreach (IDestructible destructible in destructibles)
            {
                destructible.OnDestruction(attacker);
            }
        }
    }
}
