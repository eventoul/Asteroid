using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private const string GAME_PLAY_SCENE = "GamePlay";
    private const string MENU_SCENE = "Menu";

    public void StartGame()
    {
        SceneManager.LoadScene(GAME_PLAY_SCENE);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }
}
