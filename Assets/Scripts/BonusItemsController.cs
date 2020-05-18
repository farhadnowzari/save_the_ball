using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.ScoreUtils;

public class BonusItemsController : MonoBehaviour
{
    public int Bonus;    
    [SerializeField]
    public Color BonusColor;
    void OnTriggerEnter2D(Collider2D other)
    {
        var targetGameObject = other.gameObject;
        if(targetGameObject.tag == "Player") 
        {
            ScoreUtils.GivePlayerPoint(targetGameObject, Bonus, BonusColor);
            Destroy(gameObject);
        }
    }
}
