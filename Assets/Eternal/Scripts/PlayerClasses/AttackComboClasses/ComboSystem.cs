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
        if (!_isCanAttack)
        {
            return;
        }

        InitComboTreeNode();

        if (_currentComboTreeNode.LightAttack != null)
        {
            Punch(_currentComboTreeNode.LightAttack);
        }
        else
        {
            _currentComboTreeNode = null;
        }
    }

    public void HeavyAttack()
    {
        if (!_isCanAttack)
        {
            return;
        }

        InitComboTreeNode();

        if (_currentComboTreeNode.HeavyAttack != null)
        {
            Punch(_currentComboTreeNode.HeavyAttack);
        }
        else
        {
            _currentComboTreeNode = null;
        }
    }

    private void InitComboTreeNode()
    {
        var currentState = _characterState.CurrentState;

        if (_currentComboTreeNode != null)
        {
            if (currentState != _prevState)
            {
                _currentComboTreeNode = GetComboRoot(currentState);
            }
        }
        else
        {
            _currentComboTreeNode = GetComboRoot(currentState);
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
                _currentComboTreeNode = null;
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

    private void Punch(ComboTreeNode treeNode)
    {
        OnSetAnimationTrigger?.Invoke(treeNode.AnimationId);
        treeNode.StartComboEvent?.Invoke();
        _currentComboTreeNode = treeNode;
        _timerForResetCombo = 0.0f;
        _comboResetTime = _currentComboTreeNode.ResetComboTime;
        _canAttackTime = _currentComboTreeNode.CanAttackTime;
        _isCanAttack = false;
    }
}