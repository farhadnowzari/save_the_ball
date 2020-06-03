using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformItemsController : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Diamond;
    public GameObject SlowDownPotion;

    public float SlowPotionSpawnThreshold;
    public List<Transform> Placeholders;
    [Range(0, 100)]
    public float ProbabilityToSpawnAnItem;
    [Range(0, 100)]
    public float ProbabilityToSpawnDiamond;
    [Range(0, 100)]
    public float ProbabilityToSpawnSlowDownPotion;
    public bool SpawnItems;

    void Awake()
    {
        if(!SpawnItems) return;
        foreach(var placeholder in Placeholders) {
            if(!canSpawnItem()) continue;
            if(canSpawnPotion()) {
                spawnItem(SlowDownPotion, placeholder);
                continue;
            }
            if(canSpawnDiamond()) {
                spawnItem(Diamond, placeholder);
                continue;
            }
            spawnItem(Coin, placeholder);
        }
    }

    void Update()
    {
        if(Game.CurrentScore % 50 == 0 && ProbabilityToSpawnAnItem <= 98) {
            ProbabilityToSpawnAnItem += 2;
        }
    }

    bool canSpawnItem() {
        var randomNumber = Random.Range(0, 101);
        return randomNumber <= ProbabilityToSpawnAnItem;
    }
    bool canSpawnDiamond() {
        var randomNumber = Random.Range(0, 101);
        return randomNumber <= ProbabilityToSpawnDiamond;
    }

    bool canSpawnPotion() {
        if(SlowDownPotion == null) return false;
        var randomNumber = Random.Range(0, 101);
        return Game.Speed >= SlowPotionSpawnThreshold && randomNumber <= ProbabilityToSpawnSlowDownPotion;
    }

    void spawnItem(GameObject spawnItem, Transform placeholder) {
        var position = new Vector3(placeholder.position.x, placeholder.position.y, 0);
        Instantiate(spawnItem, position, Quaternion.identity);
    }
}
