using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExternalEventsSystem : MonoBehaviour
{
    public event Action<string, int> OnStateChanged;

    public void TakeDamage(int damage)
    {
        if(OnStateChanged != null)
        {
            OnStateChanged.Invoke("Health", damage);
        }
    }
}
