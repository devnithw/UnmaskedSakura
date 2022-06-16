using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdialouge : MonoBehaviour
{
    public Animator dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        dialogue.SetBool("near", true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        dialogue.SetBool("near", false);
    }
}
