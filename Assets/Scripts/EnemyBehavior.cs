using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool movingRight = true;
    public Transform groundCheck;
    public Animator animator;
    public LayerMask EnemySightLayers;
    public float enemySightDistance;
    public LayerMask enemyCollidingLayers;
    public float patrolSpeed = 1;
    public float chaseSpeed = 3;
    public float detectRadiusAfterSeen = 10;
    public Rigidbody2D rb;
    public bool canFloat = false;


    private void Update() {

    }

    // FUNCTION TO MAKE SURE ENEMY STAYS ON PLATFORM
    public void PlatformCheck() {
        // Generate raycast to identify ground colliders

        // For platforms
        RaycastHit2D[] groundInfo = Physics2D.RaycastAll(groundCheck.position, Vector2.down, 1f, enemyCollidingLayers);

        // If ground collider is not found then flip the character accordingly
        if(groundInfo.Length == 0) {
           
            animator.SetBool("isFollowing", false);

            if (Mathf.Abs(rb.velocity.y) < 0.01f){

                if (movingRight == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                } 
                else {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
            
        }

    }

    public void WallCheck(){

        RaycastHit2D[] wallInfoRight = Physics2D.RaycastAll(transform.position, Vector2.right, 2f, enemyCollidingLayers);
        RaycastHit2D[] wallInfoLeft = Physics2D.RaycastAll(transform.position, Vector2.left, 2f, enemyCollidingLayers);

        if (wallInfoRight.Length > 0){
            animator.SetBool("isFollowing", false);
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        } else if (wallInfoLeft.Length > 0) {
            animator.SetBool("isFollowing", false);
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;

        }

    }

    public bool PlayerCheck()
    {
        // Project two raycasts both sides with distance of enemy sight
        // 
        RaycastHit2D[] sightRight = Physics2D.RaycastAll(transform.position, Vector2.right, enemySightDistance, EnemySightLayers);
        RaycastHit2D[] sightLeft = Physics2D.RaycastAll(transform.position, Vector2.left, enemySightDistance, EnemySightLayers);

        // If one    
        if(sightRight.Length > 0 || sightLeft.Length > 0)
        {
            return true;
        } else {
            return false;
        }

    }

    public void Die(){
        Destroy(gameObject);

    }

}


