﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyBindings keybindings;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool GetKeyDown(string key)
    {
        if(Input.GetKeyDown(keybindings.checkKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetKey(string key)
    {
        if (Input.GetKey(keybindings.checkKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
