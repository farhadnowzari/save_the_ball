using UnityEngine;
public class PlayerController: MonoBehaviour 
{
    public GameObject DeathEffect;
    public void Die() {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Game.State = GameState.GameOver;
        Destroy(gameObject);
    }
}