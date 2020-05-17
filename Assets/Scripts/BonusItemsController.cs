using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.ScoreUtils;

public class BonusItemsController : MonoBehaviour
{
    public int Bonus;    
    void OnTriggerEnter2D(Collider2D other)
    {
        var targetGameObject = other.gameObject;
        if(targetGameObject.tag == "Player") 
        {
            ScoreUtils.GivePlayerPoint(targetGameObject, Bonus);
            Destroy(gameObject);
        }
    }
}
