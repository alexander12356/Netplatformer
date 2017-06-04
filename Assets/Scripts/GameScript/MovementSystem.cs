using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private enum Direction
    {
        Right,
        Left
    }

    private Rigidbody2D _rigidBody2d;
    private float _moveValue;
    private Direction _currentDirection = Direction.Right;

    [SerializeField]
    private float Speed;

	private void Awake ()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();	
	}

    public void Move(float vector)
    {
        _moveValue = vector;
        CheckDirection();
    }

    private void Update ()
    {
        _rigidBody2d.velocity = new Vector2(_moveValue * Speed, _rigidBody2d.velocity.y);
    }

    private void CheckDirection()
    {
        if (_moveValue > 0 && _currentDirection == Direction.Left)
        {
            ChangeDirection();
            _currentDirection = Direction.Right;
        }
        else if (_moveValue < 0 && _currentDirection == Direction.Right)
        {
            ChangeDirection();
            _currentDirection = Direction.Left;
        }
    }

    private void ChangeDirection()
    {
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
