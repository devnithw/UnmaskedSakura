using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Animator animator;
    public AudioSource bgMusic;
    public GameObject grassSound;

    private void OnTriggerEnter2D(Collider2D other) {
        animator.SetTrigger("startLevel");
        animator.GetComponent<AudioSource>().Play();
        bgMusic.Play();
        grassSound.SetActive(false);        
        Destroy(transform.gameObject);
    }
    




}
