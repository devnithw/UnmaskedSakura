using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriGate : MonoBehaviour
{
    public LevelLoader loader;
    public Collider2D triggerCollider;
    // Start is called before the first frame update
    private void Start() {
        triggerCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            Destroy(triggerCollider);
            loader.LoadNextLevel();

        }        

    }
    
}
