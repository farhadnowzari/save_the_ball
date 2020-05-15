using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public void DestroyMe() {
        if(ExplosionEffect != null) {
            var position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            Instantiate(ExplosionEffect, position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
