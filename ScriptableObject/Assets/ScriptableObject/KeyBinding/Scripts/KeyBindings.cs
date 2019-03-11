using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class KeyBindings : ScriptableObject
{
    [Header("Character Movements")]
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;
    public KeyCode run;
    [Header("Character interactions")]
    public KeyCode interact;
    [Header("User Interface")]
    public KeyCode pauseGame;
    public KeyCode inventory;
    public KeyCode spellbook;

    public KeyCode checkKey(string key)
    {
        switch (key)
        {
            //Movement
            case "MoveForward":
                return moveForward;
            case "MoveBackward":
                return moveBackward;
            case "MoveLeft":
                return moveLeft;
            case "MoveRight":
                return moveRight;
            case "Jump":
                return jump;
            case "Run":
                return run;

            //Interactions
            case "Interact":
                return interact;

            //UI
            case "PauseGame":
                return pauseGame;
            case "Inventory":
                return inventory;
            case "Spellbook":
                return spellbook;

            default:
                return KeyCode.None;
        }
    }
}
