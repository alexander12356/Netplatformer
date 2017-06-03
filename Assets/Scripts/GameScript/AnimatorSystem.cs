using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimatorSystem : MonoBehaviour
{
    public enum AnimationType
    {
        IDLE,
        WALK,
        JUMP,
        ATTACK
    }

    private void Awake ()
    {
	}
	
	public void AnimationPlay(AnimationType anim)
    {
    }
}
