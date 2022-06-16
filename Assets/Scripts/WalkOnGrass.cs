using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnGrass : MonoBehaviour
{
    public AudioSource soundSource;
    Rigidbody2D rb;
    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        rb = GetComponentInParent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.01f && Mathf.Abs(rb.velocity.y) < 0.01f && !isPlaying){
            isPlaying = true;
            soundSource.Play();
        } else if ((Mathf.Abs(rb.velocity.x) < 0.01f || Mathf.Abs(rb.velocity.y) > 0.01f) && isPlaying){
            isPlaying = false;
            soundSource.Pause();
        }
        
    }
}
