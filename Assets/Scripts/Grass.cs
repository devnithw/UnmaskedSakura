using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        animator.SetTrigger("sway");
    }
}
