using UnityEngine;
public class PlayerController: MonoBehaviour 
{
    public AudioController GameAudio;
    public GameObject DeathEffect;
    public string DeadSoundName;
    public Transform TextPlaceholder;

    public void ShowText(GameObject TextMesh) {
        Instantiate(TextMesh, TextPlaceholder.position, Quaternion.identity, transform);
    }
    public void Die() {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Game.State = GameState.GameOver;
        GameAudio.Play(DeadSoundName);
        Destroy(gameObject);
    }
}