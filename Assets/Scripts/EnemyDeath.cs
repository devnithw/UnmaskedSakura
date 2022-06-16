using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D other) {

        // If the other collider is of the player's
        if(other.CompareTag("Player")){

            KillEnemy();
            // Trigger player's hurt funciton
            other.GetComponent<PlayerHealth>().Hurt();            
        }
        
    }

    public void KillEnemy()
    {
        // Firstd destroy the circle trigger collider to avoid furthur collisions 
        Destroy(GetComponent<CircleCollider2D>());
        // Start the death animation
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Destroy the parent enemy Game object
        Destroy(transform.parent.gameObject);

    }
}
