using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game
{
    public static GameState State = GameState.MainMenu;
    public static float CurrentScore = 0;

    public static float Speed = 3;

    public static bool Ended {
        get {
            return State == GameState.GameOver;
        }
    }

    public static bool InMainMenu {
        get {
            return State == GameState.MainMenu;
        }
    }

    public static bool Running {
        get {
            return State == GameState.Running;
        }
    }
}
