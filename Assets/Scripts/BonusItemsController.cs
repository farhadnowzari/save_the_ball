using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.ScoreUtils;

public class BonusItemsController : MonoBehaviour
{
    [HideInInspector]
    public AudioController GameAudio;
    public string PickupSoundName;
    public int Bonus;    
    [SerializeField]
    public Color BonusColor;
    
    void Awake()
    {
        GameAudio = GameObject.FindObjectOfType<AudioController>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var targetGameObject = other.gameObject;
        if(targetGameObject.tag == "Player") 
        {
            ScoreUtils.GivePlayerPoint(targetGameObject, Bonus, BonusColor);
            GameAudio.Play(PickupSoundName);
            Destroy(gameObject);
        }
    }
}
