﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenePM : MonoBehaviour
{
    public int LevelToLoad;
    public void SceneLoader()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
