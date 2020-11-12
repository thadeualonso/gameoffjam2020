using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedFreeze : MonoBehaviour, IAttackable
{
    [SerializeField] float _duration;

    private float _pendingFreezeDuration;
    private bool _isFrozen = false;

    private void Update()
    {
        if(_pendingFreezeDuration > 0 && !_isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }

    private IEnumerator DoFreeze()
    {
        _isFrozen = true;
        var originalTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(_duration);

        Time.timeScale = originalTimeScale;
        _pendingFreezeDuration = 0f;
        _isFrozen = false;
    }

    public void OnAttack(GameObject attacker, Attack attack)
    {
        _pendingFreezeDuration = _duration;
    }
}
