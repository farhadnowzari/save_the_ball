using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxesController : MonoBehaviour
{
    public float PositionToDestroy_Y;
    public float Speed;

    void Update()
    {
        if(Game.Ended) return;
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
        if(transform.position.y >= PositionToDestroy_Y) {
            Destroy(gameObject);
        }
    }
}
