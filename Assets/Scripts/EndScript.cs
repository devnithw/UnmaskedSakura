using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject player;
    public GameObject HUD;
    public Animator endCredits;
    public LevelLoader levelLoader;

    private void OnTriggerEnter2D(Collider2D other) {
        player.SetActive(false);
        HUD.SetActive(false);
        StartCoroutine(RollCredits());
        
    }

    IEnumerator RollCredits(){
        yield return new WaitForSeconds(2f);
        endCredits.SetTrigger("finish");
        yield return new WaitForSeconds(5f);
        levelLoader.LoadNextLevel();

    }

    
}
