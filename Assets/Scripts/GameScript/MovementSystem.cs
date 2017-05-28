using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;
    private float MoveValue;
    [SerializeField]
    private float Speed;

	private void Awake ()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();	
	}

    public void Move(float vector)
    {
        MoveValue = vector;
    }

    private void Update ()
    {
        _rigidBody2d.velocity = new Vector2(MoveValue * Speed, _rigidBody2d.velocity.y);
    }
}
