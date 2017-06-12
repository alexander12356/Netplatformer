using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ComboParam
{
    public string AnimationId;
    public float breakTime;
    public float canAttackTime;
}

public class Combo : MonoBehaviour
{
    [SerializeField]
    private string Id;

    [SerializeField]
    private List<ComboParam> ComboSimpleAttack = new List<ComboParam>();

    public void Punch()
    {

    }

    public void Update()
    {

    }
}
