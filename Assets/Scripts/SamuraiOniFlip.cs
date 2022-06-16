using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiOniFlip : MonoBehaviour
{
    public Transform SamuraiOni;
    bool swordFacingLeft = true;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Flip the character logic
        if(swordFacingLeft == false && player.position.x < SamuraiOni.position.x)
        {
            Flip();
        } else if (swordFacingLeft == true && player.position.x > SamuraiOni.position.x)
        {
            Flip();
        }
        
    }

    void Flip(){
        swordFacingLeft = !swordFacingLeft;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
