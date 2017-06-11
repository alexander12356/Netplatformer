using System;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public struct ComboList
{
    public CharacterState.State characterState;
    public Combo combo;
}

public class ComboSystem : MonoBehaviour
{
    public event Action<string> OnSetAnimationTrigger;
    public CharacterState _characterState;

    [SerializeField]
    private List<ComboList> _comboList;

    public CharacterState CharacterState
    {
        set
        {
            _characterState = value;
        }
    }

    public void Attack()
    {
        for (int i = 0; i < _comboList.Count; i++)
        {
            switch (_comboList[i].characterState)
            {
                case CharacterState.State.Moving:
                    break;
                case CharacterState.State.Idle:
                    break;
                case CharacterState.State.Attack:
                    break;
                default:
                    break;
            }
        }
    }
}