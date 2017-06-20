using System;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public struct ComboList
{
    public CharacterState.State characterState;
    public ComboTreeNode comboTreeNode;
}

public class ComboSystem : MonoBehaviour
{
    public event Action<string> OnSetAnimationTrigger;
    public enum AttackType
    {
        LightAttack,
        HeavyAttack
    }

    [Header("For Debug")]
    [SerializeField]
    private ComboTreeNode _currentComboTreeNode;
    [SerializeField]
    private float _comboResetTime;
    [SerializeField]
    private float _timerForResetCombo;
    [SerializeField]
    private float _canAttackTime;
    [SerializeField]
    private float _timerForCanAttack;

    [Header("Properties")]
    public List<ComboList> ComboTrees;
    
    private CharacterState.State _prevState = CharacterState.State.NONE;
    private CharacterState _characterState;
    private bool _isCanAttack = true;

    public CharacterState CharacterState
    {
        set
        {
            _characterState = value;
        }
    }

    public void LightAttack()
    {
        Punch(AttackType.LightAttack);
    }

    public void HeavyAttack()
    {
        Punch(AttackType.HeavyAttack);
    }

    private void InitComboTreeNode()
    {
        var currentState = _characterState.CurrentState;

        if (_currentComboTreeNode != null)
        {
            if (currentState != _prevState)
            {
                ChangeCurrentComboTreeNode(GetComboRoot(currentState));
            }
        }
        else
        {
            ChangeCurrentComboTreeNode(GetComboRoot(currentState));
        }
        _prevState = currentState;
    }

    private ComboTreeNode GetComboRoot(CharacterState.State currentState)
    {
        for (int i = 0; i < ComboTrees.Count; i++)
        {
            if (ComboTrees[i].characterState == currentState)
            {
                return ComboTrees[i].comboTreeNode;
            }
        }
        return null;
    }

    private void Update()
    {
        if (_currentComboTreeNode != null)
        {
            if (_timerForResetCombo < _comboResetTime)
            {
                _timerForResetCombo += Time.deltaTime;
            }
            else
            {
                _timerForResetCombo = 0.0f;
                ChangeCurrentComboTreeNode(null);
            }    
        }

        if (!_isCanAttack)
        {
            if (_timerForCanAttack < _canAttackTime)
            {
                _timerForCanAttack += Time.deltaTime;
            }
            else
            {
                _timerForCanAttack = 0.0f;
                _isCanAttack = true;
            }
        }
    }

    private void Punch(AttackType attackType)
    {
        if (!_isCanAttack)
        {
            return;
        }

        var currentState = _characterState.CurrentState;
        if (_currentComboTreeNode == null || currentState != _prevState)
        {
            ChangeCurrentComboTreeNode(GetComboRoot(currentState));
        }
        _prevState = currentState;

        switch (attackType)
        {
            case AttackType.LightAttack:
                ChangeCurrentComboTreeNode(_currentComboTreeNode.LightAttack);
                break;
            case AttackType.HeavyAttack:
                ChangeCurrentComboTreeNode(_currentComboTreeNode.HeavyAttack);
                break;
            default:
                break;
        }
    }

    private void ChangeCurrentComboTreeNode(ComboTreeNode newComboTreeNode)
    {
        _timerForResetCombo = 0.0f;
        _currentComboTreeNode?.EndComboEvent?.Invoke();

        _currentComboTreeNode = newComboTreeNode;
        if (_currentComboTreeNode == null)
        {
            return;
        }
        OnSetAnimationTrigger?.Invoke(_currentComboTreeNode.AnimationId);
        _currentComboTreeNode?.StartComboEvent?.Invoke();
        
        _comboResetTime = _currentComboTreeNode.ResetComboTime;
        _canAttackTime = _currentComboTreeNode.CanAttackTime;
        _isCanAttack = false;
    }
}