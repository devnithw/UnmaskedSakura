using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 3;
    public int damage = 1;
    public Transform A;
    public Transform B;
    public GameObject player;
    public Animator animator;
    public GameObject deathEffect;
    Vector2 pos;
    float cooldownTime = 0f;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayer;
    public AudioSource bgMusic;
    public GameObject grassSound;
    public GameObject LevelLoader;
    public AudioSource HurtSound;
    public ParticleSystem particles;
    public float difficulty = 1f;
    public int particleNum = 50;
    public float cloudBoundsX = -0.2f;
    public float cloudBoundsY = +3.2f;


    public void Attack(){
        // Detect for enemies
        Collider2D hitInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (hitInfo != null){
            hitInfo.GetComponent<PlayerHealth>().Hurt();
        }

    }

    public void Hurt(){
        // Reduce health variable
        health -= 1;
        particles.Emit(particleNum);

        if (health == 0) {
            // Firstd destroy the circle trigger collider to avoid furthur collisions 
            Destroy(GetComponent<CircleCollider2D>());
            StartCoroutine(KillBoss());           

        } else {
            HurtSound.Play();
        }

    }

    IEnumerator KillBoss(){
        //Play death animation
        animator.SetTrigger("death");
        pos = new Vector2(transform.position.x + cloudBoundsX, transform.position.y + cloudBoundsY); 
        yield return new WaitForSeconds(1.5f);
        // Start the death animation
        Instantiate(deathEffect, pos, Quaternion.identity);
        yield return new WaitForSeconds(4.5f);
        bgMusic.GetComponent<Animator>().SetTrigger("fade_out");
        grassSound.SetActive(true);
        yield return new WaitForSeconds(5f);
        LevelLoader.GetComponent<LevelLoader>().LoadNextLevel();
        // Destroy the boss enemy Game object
        Destroy(transform.gameObject);

    }

    void OnTriggerEnter2D(Collider2D other) {
        // If the other collider is of the player's
        if(other.CompareTag("Player") && Time.time >= cooldownTime){
            // Trigger player's hurt funciton
            other.GetComponent<PlayerHealth>().Hurt();
            cooldownTime = Time.time + 1.5f;            
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null)
        {  
            return;            
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void SlashSound() {
        attackPoint.GetComponent<AudioSource>().Play();
    }



}
