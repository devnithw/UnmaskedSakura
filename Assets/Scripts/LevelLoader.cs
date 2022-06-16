using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator audioFade; 
    public float transition_time = 1;
    // Load index
    // For next level = 0
    // For main menu = 1
    // For Level1 = 2
    public int loadIndex = 0;

    public void LoadNextLevel(){

        StartCoroutine(LoadLevel(loadIndex));        

    }

    IEnumerator LoadLevel(int index){

        transition.SetTrigger("crossfade");
        audioFade.SetTrigger("fade_out");
        yield return new WaitForSeconds(transition_time);
        if (index == 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else if (index == 1){
            SceneManager.LoadScene("MainMenu");
        } else if (index == 2){
            SceneManager.LoadScene("Level1");
        }
        

    }




}
