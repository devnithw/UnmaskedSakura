using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public Animator animator;
    public bool zoom = true;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(zoom){
            animator.Play("Zoomed");
        } else {
            animator.Play("Normal");
        }
        
    }
}
