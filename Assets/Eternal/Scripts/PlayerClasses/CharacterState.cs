using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public enum State
    {
        NONE = -1,
        Moving,
        Idle,
        Attack
    }

    [SerializeField]
    private State _currentState = State.Idle;

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
        controlSystem.OnLightAttackKeyDown += combatSystem.LightAttack;
        controlSystem.OnHeavyAttackKeyDown += combatSystem.HeavyAttack;
        controlSystem.OnJumpKeyDown += movementSystem.Jump;

        combatSystem.OnSetAnimationTrigger += animatorSystem.AnimationSetTrigger;
        combatSystem.CharacterState = this;

        movementSystem.OnChangeState += ChangeState;
    }
}
