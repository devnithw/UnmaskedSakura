using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public AudioSource audioSource;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if attack button is pressed and player is not jumping
        if (Input.GetKeyDown(KeyCode.Z) && Mathf.Abs(rb.velocity.y) < 0.01)
        {
            Attack();
        }
        
    }

    void Attack()
    {
        // Set animation
        animator.SetTrigger("attack");
        audioSource.Play();

        // Detect for enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit enemy" + enemy.name);
            enemy.GetComponentInChildren<EnemyDeath>().KillEnemy();            
        }

    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null)
        {  
            return;            
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
