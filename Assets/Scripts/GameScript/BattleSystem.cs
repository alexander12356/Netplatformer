using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    public event Action<AnimatorSystem.AnimationType> OnRunAnimation;

    public void Attack()
    {
        if(OnRunAnimation != null)
        {
            OnRunAnimation.Invoke(AnimatorSystem.AnimationType.ATTACK);
            weapon.StartAttack();
        }
    }
}
