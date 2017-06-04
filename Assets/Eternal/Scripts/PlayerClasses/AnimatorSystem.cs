using System;
using UnityEngine;

public class AnimatorSystem : MonoBehaviour
{
    private Animator _animator;

    private void Awake ()
    {
        _animator = GetComponent<Animator>();
	}
	
	public void AnimationStart(KeyCode keyCode)
    {
        var animationId = GetAnimationId(keyCode);
        _animator.SetBool(animationId, true);
    }

    public void AnimationStop(KeyCode keyCode)
    {
        var animationId = GetAnimationId(keyCode);
        _animator.SetBool(animationId, false);
    }

    public void AnimationSetTrigger(string animationId)
    {
        _animator.SetTrigger(animationId);
    }

    private string GetAnimationId(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                return "Moving";
            case KeyCode.D:
                return "Moving";
            case KeyCode.Space:
                return "Jump";
            default:
                return string.Empty;
        }
    }
}