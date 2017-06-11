using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControlSystem : MonoBehaviour
{
    public event Action OnLeftKeyPress;
    public event Action OnLeftKeyUp;
    public event Action OnRightKeyPress;
    public event Action OnRightKeyUp;
    public event Action OnJumpKeyDown;
    public event Action OnAttackKeyDown;

    public event Action<float> OnGetAxis;

    private void Update()
    {
        UpdateMovingControl();
        UpdateCombatControl();
    }

    private void UpdateCombatControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttackKeyDown?.Invoke();
        }
    }

    private void UpdateMovingControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            OnRightKeyPress?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            OnRightKeyUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnLeftKeyPress?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            OnLeftKeyUp?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpKeyDown?.Invoke();
        }
        
        OnGetAxis?.Invoke(Input.GetAxis("GameHorizontal"));
    }
}
