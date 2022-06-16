using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tengu : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // If the other collider is of the player's
        if(other.CompareTag("Player")){
            isFollowing = true;
            Destroy(GetComponent<BoxCollider2D>());           
        }
    }
}
