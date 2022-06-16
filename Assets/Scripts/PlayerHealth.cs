using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    SpriteRenderer s_renderer;
    public int health = 5;
    public int maxHealth = 5;
    Color tmp;

    public GameObject deathCloudEffect;

    public Rigidbody2D rb;
    public Animator transition;
    public Animator audioFade;
    bool hurtAnimationPlaying = false;
    public Component shadowCaster;
   


    // Start is called before the first frame update
    void Start()
    {
        // Get the player's sprite renderer to make the hurt flash effect
        s_renderer = GetComponent<SpriteRenderer>();

        // To stop player moving after death
        rb = GetComponent<Rigidbody2D>();        

        // Get player health from previous level
        health = PlayerPrefs.GetInt("health");
        
        // A quick fix for debugging
        if(health < 1 || SceneManager.GetActiveScene().name == "Level1"){
            health = maxHealth;
        }       
    }

    public void Hurt()
    {
        Debug.Log("Player got hurt");
        health -= 1;
        if (!hurtAnimationPlaying){
            StartCoroutine(HurtAnimation());
            hurtAnimationPlaying = true;
        }
        
        
        // Check is health is zero and load game over screen
        if (health == 0){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(shadowCaster);
            StartCoroutine(GameOver());
        }
            
    }

    private IEnumerator HurtAnimation(){

        for (int i = 0; i < 3; i++)
        {
            // Get current color
            tmp =  s_renderer.color;
            // Set transparency
            s_renderer.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.09f);
            // Again set default color
            s_renderer.color = tmp;
            yield return new WaitForSeconds(0.09f);
                
        }

        hurtAnimationPlaying = false;        

    }

    private IEnumerator GameOver(){
        // Stop player moving and set velocity to zero
        Destroy(GetComponent<PlayerMovement>());
        rb.velocity = Vector2.zero;
        //Stop enemies from approching player
        transform.gameObject.tag = "NotPlayer";
        // Spawn death clouds
        Instantiate(deathCloudEffect, transform.position, Quaternion.identity);
        Debug.Log("Loading gameover scene");
        yield return new WaitForSeconds(2f);
        //Fade out
        transition.SetTrigger("crossfade");
        audioFade.SetTrigger("fade_out");
        PlayerPrefs.SetInt("health", maxHealth);
        yield return new WaitForSeconds(1.03f);
        // Load game over scene
        SceneManager.LoadScene("GameOver");
    }

    public void Heal(int num){
        if (health < maxHealth){
            health += num;
        }
        
    }
    private void OnDestroy() {
        Debug.Log("player destroyed");
        PlayerPrefs.SetInt("health", health);
    }
}
