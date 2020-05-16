using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItemsController : MonoBehaviour
{
    public int Bonus;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        var targetGameObject = other.gameObject;
        if(targetGameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
