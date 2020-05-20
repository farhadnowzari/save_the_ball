using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public float RespawnPoint;
    public float PointToRespawn;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= PointToRespawn) {
            transform.position = new Vector2(0, RespawnPoint);
        }
    }
}
