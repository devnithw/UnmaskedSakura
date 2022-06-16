using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Transform endPosition;
    public float speed = 1;
    public Animator animator;
    bool flying = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            Destroy(GetComponent<CircleCollider2D>());
            animator.SetTrigger("fly");
            flying = true;

        }
    }

    private void Update() {
        if (flying){
            transform.position = Vector2.MoveTowards(transform.position, endPosition.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, endPosition.position) < 0.01f){
            Destroy(transform.gameObject);
        }
        
    }

   
}
