using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ComboParam
{
    public string AnimationId;
    public float Time;
}

public class Combo : MonoBehaviour
{
    [SerializeField]
    private string Id;

    [SerializeField]
    private List<ComboParam> ComboSimpleAttack;
}
