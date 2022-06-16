using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void PlayGame(){
        levelLoader.LoadNextLevel();
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
