using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCompositor : MonoBehaviour
{
	public void Start ()
    {
        var animatorSystem = GetComponent<AnimatorSystem>();
        var movementSystem = GetComponent<MovementSystem>();
        var controlSystem = GetComponent<ControlSystem>();
        var combatSystem = GetComponent<BattleSystem>();

        controlSystem.OnGetAxis += movementSystem.Move;
        controlSystem.OnGetKey += animatorSystem.AnimationStart;
        controlSystem.OnGetKeyUp += animatorSystem.AnimationStop;
        controlSystem.OnMouseButtonDown += combatSystem.Attack;

        combatSystem.OnRunCombo += animatorSystem.AnimationSetTrigger;
    }
}
