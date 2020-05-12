using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Properties
    public Direction2D Direction;
    [Range(0, 100)]
    public float Speed;
    #endregion
    private Rigidbody2D mainRigidBody;  
    void Awake()
    {
        mainRigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
