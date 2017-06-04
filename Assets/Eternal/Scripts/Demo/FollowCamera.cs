using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float dampTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Vector2 deltaCameraPos;

    private void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.5f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.5f, target.position.z) - Camera.main.ViewportToWorldPoint(new Vector3(deltaCameraPos.x, deltaCameraPos.y, point.z));
            Vector3 destination = transform.position + delta;


            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
