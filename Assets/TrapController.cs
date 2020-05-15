using UnityEngine;

public class TrapController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var targetObject = other.gameObject;
        if(targetObject.layer == (int)Layers.Platform) {
            var platformController = targetObject.GetComponent<PlatformController>();
            platformController.DestroyMe();
        }
    }
}
