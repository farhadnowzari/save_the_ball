using UnityEngine;

public class PotionsController : MonoBehaviour
{
    [HideInInspector]
    public AudioController GameAudio;
    public string Name;
    public PotionType Type;
    public float EffectFator;
    [SerializeField]
    public Color TextColor;
    public string PickupSoundName;
    public GameObject TextMesh;

    private EnvironmentController environmentController;

    void Awake()
    {
        GameAudio = GameObject.FindObjectOfType<AudioController>();    
        environmentController = GameObject.FindObjectOfType<EnvironmentController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var targetGameObject = other.gameObject;
        if(targetGameObject.tag == "Player") 
        {
            var playerController = targetGameObject.GetComponent<PlayerController>();
            playerController.ShowText(buildText());
            GameAudio.Play(PickupSoundName);
            SetTheEffect();
            Destroy(gameObject);
        }
    }

    GameObject buildText() {
        var textMeshComponent = TextMesh.GetComponent<TextMesh>();
        textMeshComponent.text = Name;
        textMeshComponent.color = TextColor;
        textMeshComponent.characterSize = .7f;
        return TextMesh;
    }

    void SetTheEffect() {
        if(Type == PotionType.SlowdownFalling) {
            environmentController.SlowDown(EffectFator);
        }
    }
}
