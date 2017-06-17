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

    [Header("Property")]
    public float ComboResetTime;
    public List<ComboList> ComboTrees;
    
    private float _timerForResetCombo;
    private CharacterState.State _prevState = CharacterState.State.NONE;
    private CharacterState _characterState;

    public CharacterState CharacterState
    {
        set
        {
            _characterState = value;
        }
    }

    public void LightAttack()
    {
        InitComboTreeNode();

        if (_currentComboTreeNode.LightAttack != null)
        {
            OnSetAnimationTrigger?.Invoke(_currentComboTreeNode.LightAttack.AnimationId);
            _currentComboTreeNode = _currentComboTreeNode.LightAttack;
            _timerForResetCombo = 0.0f;
        }
        else
        {
            _currentComboTreeNode = null;
        }
    }

    public void HeavyAttack()
    {
        InitComboTreeNode();

        if (_currentComboTreeNode.HeavyAttack != null)
        {
            OnSetAnimationTrigger?.Invoke(_currentComboTreeNode.HeavyAttack.AnimationId);
            _currentComboTreeNode = _currentComboTreeNode.HeavyAttack;
            _timerForResetCombo = 0.0f;
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
            if (_timerForResetCombo < ComboResetTime)
            {
                _timerForResetCombo += Time.deltaTime;
            }
            else
            {
                _timerForResetCombo = 0.0f;
                _currentComboTreeNode = null;
            }
        }
    }
}