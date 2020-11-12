using DG.Tweening;
using UnityEngine;

public class AttackedScreenShake : MonoBehaviour, IAttackable
{
    [SerializeField] float _duration;
    [SerializeField] float _strength;
    [SerializeField] int _vibrato;
    [SerializeField] float _randomness;

    public void OnAttack(GameObject attacker, Attack attack)
    {
        Camera.main.DOShakePosition(_duration, _strength, _vibrato, _randomness);
    }
}