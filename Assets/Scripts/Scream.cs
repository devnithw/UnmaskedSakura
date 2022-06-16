using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public AudioSource scream;
    public EnemyBehavior behavior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (behavior.PlayerCheck() && !scream.isPlaying){
            scream.Play();
        }
        
    }
}
