using System;
using UnityEngine;

public class AnimatorSystem : MonoBehaviour
{
    private Animator _animator;

    private void Awake ()
    {
        _animator = GetComponent<Animator>();
	}
	
    public void PlayMovingAnimation()
    {
        _animator.SetBool("Moving", true);
    }

    public void StopMovingAnimation()
    {
        _animator.SetBool("Moving", false);
    }

    public void AnimationSetTrigger(string animationId)
    {
        _animator.SetTrigger(animationId);
    }
}