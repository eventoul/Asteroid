using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private const string GAME_OVER_SCENE = "GameOver";

    public void Crash()
    {
        gameObject.SetActive(false); // apenergopoihsh toy gameobejct.

        Invoke(nameof(LoadGameOverScene), 1f); // kalei tin methodo meta apo 1 sec
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(GAME_OVER_SCENE);
    }
}
