using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DragonBones;
using System;

public enum CharacterDirection
{
    Left,
    Right
}

public enum CharacterState
{
    Idle,
    Walking
}

public class SwordsmenCharacter : MonoBehaviour
{
    private CharacterState _characterState;
    private UnityArmatureComponent _unityArmatureComponent;
    private Rigidbody2D _rigidBody2d;
    private bool _isGrounded = false;
    private SwordsmenNetwork _swordsmenNetwork;

    public CharacterDirection CurrentDirection;

    [Header("Moving properties")]
    public float Speed;
    public float JumpForce;

    [Header("Ground check")]
    public UnityEngine.Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    [Header("")]
    public float MoveValue;

    private void Awake()
    {
        _unityArmatureComponent = GetComponent<UnityArmatureComponent>();
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _swordsmenNetwork = GetComponent<SwordsmenNetwork>();
    }

    private void Start()
    {
        _characterState = CharacterState.Idle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeState(CharacterState.Walking);
            SetDirection(CharacterDirection.Right);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState(CharacterState.Walking);
            SetDirection(CharacterDirection.Left);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            ChangeState(CharacterState.Idle);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ChangeState(CharacterState.Idle);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _swordsmenNetwork.PlayAnimation("attack1");
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2d.AddForce(new Vector2(0f, JumpForce));
            _swordsmenNetwork.PlayAnimation("jump");
        }

        _rigidBody2d.velocity = new Vector2(MoveValue * Speed, _rigidBody2d.velocity.y);
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        MoveValue = Input.GetAxis("Horizontal");
    }

    private void PlayAnimation()
    {
        switch (_characterState)
        {
            case CharacterState.Idle:
                _swordsmenNetwork.PlayAnimation("steady");
                break;
            case CharacterState.Walking:
                _swordsmenNetwork.PlayAnimation("walk");
                break;
            default:
                break;
        }
    }

    public void PlayAnimation(string id)
    {
        _unityArmatureComponent.animation.Play(id);
    }

    public void StopAnimation(string id)
    {
        _unityArmatureComponent.animation.Stop(id);
    }

    private void ChangeState(CharacterState characterState)
    {
        _characterState = characterState;

        PlayAnimation();
    }

    private void SetDirection(CharacterDirection newDirection)
    {
        _swordsmenNetwork.Flip(newDirection == CharacterDirection.Left ? true : false);
        CurrentDirection = newDirection;
    }

    public void ChangeFlip(bool value)
    {
        _unityArmatureComponent.armature.flipX = value;
    }
}
