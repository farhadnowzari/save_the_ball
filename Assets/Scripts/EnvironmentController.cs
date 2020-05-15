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
        var lastPlaceholderIndex = MainPlatformRenderer.LastPlaceholderIndex;
        var newPlaceholderIndex = Mathf.Abs(lastPlaceholderIndex - 1);
        var placeholder = MainPlatformRenderer.Placeholders[newPlaceholderIndex];
        var platformType = PlatformUtils.RandomizePlatformType();
        GameObject platform = null;
        if(platformType == PlatformType.LongPlatform) {
            platform = MainPlatformRenderer.LongPlatform;
        } else if(platformType == PlatformType.ShortPlatform) {
            platform = MainPlatformRenderer.ShortPlatform;
        } else {
            platform = MainPlatformRenderer.SinglePlatform;
        }
        var position = new Vector3(placeholder.position.x, placeholder.position.y, 0);
        MainPlatformRenderer.IncreaseSpeed();
        platform = Instantiate(platform, position, Quaternion.identity);
        var platformMovementController = platform.GetComponent<PlatformAutoMoveController>();
        platformMovementController.Speed = MainPlatformRenderer.PlatformSpeed;
        MainPlatformRenderer.LastPlaceholderIndex = newPlaceholderIndex;
    }
}
