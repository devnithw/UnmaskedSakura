using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public LevelLoader levelLoader;
    
    public void MainMenu(){
        levelLoader.LoadNextLevel();
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
