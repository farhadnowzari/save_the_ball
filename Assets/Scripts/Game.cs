﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static GameState State = GameState.Running;

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
