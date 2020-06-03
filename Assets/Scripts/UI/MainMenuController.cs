using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartTheGame() {
        Game.State = GameState.Running;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
