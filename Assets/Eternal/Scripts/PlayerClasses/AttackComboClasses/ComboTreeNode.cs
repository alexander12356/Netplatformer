using UnityEngine;
using UnityEngine.Events;

public class ComboTreeNode : MonoBehaviour
{
    public string AnimationId;
    public ComboTreeNode LightAttack;
    public ComboTreeNode HeavyAttack;
    public float CanAttackTime;
    public float ResetComboTime;
    public UnityEvent StartComboEvent;
    public UnityEvent EndComboEvent;
}
