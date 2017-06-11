using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public enum State
    {
        Moving,
        Idle,
        Attack
    }

    private State _currentState;

    public State CurrentState
    {
        get { return _currentState; }
    }

    public void ChangeState(State newState)
    {
        _currentState = newState;
    }

	public void Start ()
    {
        var animatorSystem = GetComponent<AnimatorSystem>();
        var movementSystem = GetComponent<MovementSystem>();
        var controlSystem = GetComponent<ControlSystem>();
        var combatSystem = GetComponent<ComboSystem>();

        controlSystem.OnGetAxis += movementSystem.Move;
        controlSystem.OnLeftKeyPress += animatorSystem.PlayMovingAnimation;
        controlSystem.OnLeftKeyUp += animatorSystem.StopMovingAnimation;
        controlSystem.OnRightKeyPress += animatorSystem.PlayMovingAnimation;
        controlSystem.OnRightKeyUp += animatorSystem.StopMovingAnimation;
        controlSystem.OnAttackKeyDown += combatSystem.Attack;
        controlSystem.OnJumpKeyDown += movementSystem.Jump;

        combatSystem.OnSetAnimationTrigger += animatorSystem.AnimationSetTrigger;
    }
}
