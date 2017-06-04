using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControlSystem : MonoBehaviour
{
    public event Action<KeyCode> OnGetKey;
    public event Action<KeyCode> OnGetKeyUp;
    public event Action<KeyCode> OnGetKeyDown;
    public event Action<float> OnGetAxis;

    public event Action<int> OnMouseButtonDown;

    private void Update()
    {
        UpdateMovingControl();
        UpdateCombatControl();
    }

    private void UpdateCombatControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown?.Invoke(0);
        }
    }

    private void UpdateMovingControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            OnGetKey?.Invoke(KeyCode.D);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            OnGetKeyUp?.Invoke(KeyCode.D);
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnGetKey?.Invoke(KeyCode.A);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            OnGetKeyUp?.Invoke(KeyCode.A);
        }
        
        OnGetAxis?.Invoke(Input.GetAxis("GameHorizontal"));
    }
}
