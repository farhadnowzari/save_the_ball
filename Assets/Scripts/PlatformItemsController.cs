using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformItemsController : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Diamond;
    public List<Transform> Placeholders;
    [Range(0, 100)]
    public float ProbabilityToSpawnAnItem;
    [Range(0, 100)]
    public float ProbabilityToSpawnDiamond;
    public bool SpawnItems;

    void Awake()
    {
        if(!SpawnItems) return;
        foreach(var placeholder in Placeholders) {
            if(!canSpawnItem()) continue;
            if(canSpawnDiamond()) {
                spawnItem(Diamond, placeholder);
                continue;
            }
            spawnItem(Coin, placeholder);
        }
    }

    void Update()
    {
        if(Game.CurrentScore % 50 == 0 && ProbabilityToSpawnAnItem < 100) {
            ProbabilityToSpawnAnItem += 1;
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

    void spawnItem(GameObject spawnItem, Transform placeholder) {
        var position = new Vector3(placeholder.position.x, placeholder.position.y, 0);
        Instantiate(spawnItem, position, Quaternion.identity);
    }
}
