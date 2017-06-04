using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public struct ComboParam
{
    public string AnimationId;
    public float Time;
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private int _currentComboStep = 0;

    [SerializeField]
    private float _currentComboTime;

    public List<ComboParam> ComboSimpleAttack;
    public event Action<string> OnRunCombo;

    public void Attack(int mouseButtonId)
    {
        if (mouseButtonId == 0)
        {
            OnRunCombo?.Invoke(ComboSimpleAttack[_currentComboStep].AnimationId);
            _currentComboTime += ComboSimpleAttack[_currentComboStep].Time;
            _currentComboStep++;

            if (_currentComboStep >= ComboSimpleAttack.Count)
            {
                _currentComboStep = ComboSimpleAttack.Count - 1;
            }
        }
    }

    private void Update()
    {
        if (_currentComboTime > 0.0f)
        {
            _currentComboTime -= Time.deltaTime;

            if (_currentComboTime <= 0.0f)
            {
                _currentComboTime = 0.0f;
                _currentComboStep = 0;
                OnRunCombo?.Invoke("AttackBreak");
            }
        }
    }
}