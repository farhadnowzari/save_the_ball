using UnityEngine;
using Utils.PlatformRenderer;
using Utils.MovementUtils;
using Utils.PlatformUtils;
public class EnvironmentController : MonoBehaviour
{

    #region Properties
    public PlatformRenderer MainPlatformRenderer;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(MainPlatformRenderer.CanSpawn()) {
            SpawnPlatform();
        }
    }

    void SpawnPlatform() {
        int shortPlatformsSpawned = 0;
        MainPlatformRenderer.ShuffleShortPlatforms();
        foreach(Transform placeholder in MainPlatformRenderer.ShortPlatformPlaceholders) {
            if(shortPlatformsSpawned > 1) break;
            shortPlatformsSpawned += 1;
            var position = new Vector3(placeholder.position.x, placeholder.position.y, 0);
            var platform = Instantiate(MainPlatformRenderer.ShortPlatform, position, Quaternion.identity);
            MainPlatformRenderer.IncreaseSpeed();
            platform.GetComponent<PlatformAutoMoveController>().Speed = MainPlatformRenderer.PlatformSpeed;
        }
    }
}
