using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAutoMoveController : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D mainRigidBody;
    void Awake()
    {
        mainRigidBody = GetComponent<Rigidbody2D>();
        if(transform.position.x < 0) {
            direction = Direction2D.Right;
        } else {
            direction = Direction2D.Left;
        }
    }
    void Update()
    {
        mainRigidBody.velocity = Vector2.up * Speed;
    }
}
