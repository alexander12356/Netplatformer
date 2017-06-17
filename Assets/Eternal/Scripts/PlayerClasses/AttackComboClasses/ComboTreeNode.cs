using UnityEngine;

public class ComboTreeNode : MonoBehaviour
{
    public string AnimationId;
    public ComboTreeNode LightAttack;
    public ComboTreeNode HeavyAttack;
    public float canAttackTime;
    public float resetComboTime;
}
