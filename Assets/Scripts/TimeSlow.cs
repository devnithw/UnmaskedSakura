using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{   
    public Rigidbody2D PlayerRB;
    public Animator animator;
    Vector2 Velocity;
    public bool timeIsSlowed = false;
    public AudioSource bgMusic;
    private void OnTriggerEnter2D(Collider2D other) {
        if (timeIsSlowed){
            SpeedUp();
        } else {
            SlowDown();
        }
        
    }

    public void SlowDown(){
        PlayerRB.gravityScale = 0f;
        Velocity = new Vector2(PlayerRB.velocity.x, -7.5f);
        PlayerRB.velocity = Velocity;
        animator.Play("Zoomed");
        if (!bgMusic.isPlaying){
            bgMusic.Play();
        }

        timeIsSlowed = true;

    }

    public void SpeedUp(){
        PlayerRB.gravityScale = 4f;
        animator.Play("Normal");
        bgMusic.GetComponent<Animator>().SetTrigger("fade_out");     
        timeIsSlowed = false;

    }


}
