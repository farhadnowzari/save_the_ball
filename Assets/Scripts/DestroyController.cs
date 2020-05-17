using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public float DestroyTime;

    void Awake()
    {
        Destroy(gameObject, DestroyTime);    
    }
}
