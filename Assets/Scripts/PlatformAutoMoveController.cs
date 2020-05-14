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
    }
    void Update()
    {
        mainRigidBody.velocity = Vector2.up * Speed;
    }
}
