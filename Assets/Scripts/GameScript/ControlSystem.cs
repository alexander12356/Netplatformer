using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControlSystem : MonoBehaviour
{
    public event Action<float> OnMove;
    public event Action<AnimatorSystem.AnimationType> OnAnimate;
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (OnAnimate != null)
            {
                OnAnimate.Invoke(AnimatorSystem.AnimationType.WALK);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (OnAnimate != null)
            {
                OnAnimate.Invoke(AnimatorSystem.AnimationType.WALK);
            }
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            if (OnAnimate != null)
            {
                OnAnimate.Invoke(AnimatorSystem.AnimationType.IDLE);
            }
        }

        if (OnMove != null)
        {
            OnMove.Invoke(Input.GetAxis("Horizontal"));
        }
    }
}
