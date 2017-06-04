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

    private void Update()
    {
        UpdateMovingControl();
    }

    private void UpdateMovingControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (OnGetKey != null)
            {
                OnGetKey.Invoke(KeyCode.D);
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (OnGetKeyUp != null)
            {
                OnGetKeyUp.Invoke(KeyCode.D);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (OnGetKey != null)
            {
                OnGetKey.Invoke(KeyCode.A);
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            if (OnGetKeyUp != null)
            {
                OnGetKeyUp.Invoke(KeyCode.A);
            }
        }

        if (OnGetAxis != null)
        {
            OnGetAxis.Invoke(Input.GetAxis("GameHorizontal"));
        }
    }
}
