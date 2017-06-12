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

    public void LightAttack()
    {
        for (int i = 0; i < _comboList.Count; i++)
        {
            //if 
        }
        OnSetAnimationTrigger?.Invoke("LightAttack_1");
    }

    public void HeavyAttack()
    {
        OnSetAnimationTrigger?.Invoke("HeavyAttack");
    }

    public void CanAttack()
    {

    }
}