using UnityEngine;
using Utils.PlatformRenderer;
using Utils.SkyboxRenderer;
using Utils.PlatformUtils;
public class EnvironmentController : MonoBehaviour
{

    #region Properties
    public PlatformRenderer MainPlatformRenderer;
    public SkyboxRenderer MainSkyboxRenderer;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(MainPlatformRenderer.CanSpawn() && !Game.Ended) {
            SpawnPlatform();
        } else if(!Game.Ended) {
            SpawnSkybox();
            TranslateWalls();
        }

    }

    void SpawnSkybox() {
        var spawnCount = MainSkyboxRenderer.CanSpawnCount();
        if(spawnCount == 2) {
            var skybox1 = MainSkyboxRenderer.GetRandomSkybox();
            var skybox2 = MainSkyboxRenderer.GetRandomSkybox();
            skybox1 = Instantiate(skybox1, Vector2.zero, Quaternion.identity);
            skybox2 = Instantiate(skybox2, new Vector2(0, -11.8f), Quaternion.identity);
            MainSkyboxRenderer.AddActiveBox(skybox1);
            MainSkyboxRenderer.AddActiveBox(skybox2);
            skybox1.GetComponent<SkyBoxesController>().Speed = MainSkyboxRenderer.Speed;
            skybox2.GetComponent<SkyBoxesController>().Speed = MainSkyboxRenderer.Speed;
            MainSkyboxRenderer.IncreaseSpeed();
        } else if(spawnCount == 1) {
            var skybox1 = MainSkyboxRenderer.GetRandomSkybox();
            skybox1 = Instantiate(skybox1, new Vector2(0, -11.8f), Quaternion.identity);
            MainSkyboxRenderer.AddActiveBox(skybox1);
            MainSkyboxRenderer.ActiveSkyboxes.ForEach(s => {
                s.GetComponent<SkyBoxesController>().Speed = MainSkyboxRenderer.Speed;
            });
            MainSkyboxRenderer.IncreaseSpeed();
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
    void TranslateWalls() {
        foreach(var wall in MainPlatformRenderer.Walls) {
            wall.transform.Translate(Vector2.up * Time.deltaTime * MainPlatformRenderer.PlatformSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var targetObject = other.gameObject;
        if(targetObject.tag == Tags.Player.ToString()) {
            var playerController = targetObject.GetComponent<PlayerController>();
            playerController.Die();
        }        
    }

    public void SlowDown(float amount) {
        MainPlatformRenderer.SlowDown(amount);
    }
}
