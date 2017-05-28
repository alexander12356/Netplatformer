using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AnimatorSystem : MonoBehaviour
{
    public enum AnimationType
    {
        IDLE,
        WALK,
        JUMP,
        ATTACK
    }

    private UnityArmatureComponent _animator;

    private void Awake ()
    {
        _animator = GetComponent<UnityArmatureComponent>();
	}
	
	public void AnimationPlay(AnimationType anim)
    {
        _animator.animation.Play(anim.ToString());
    }
}
