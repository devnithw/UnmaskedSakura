using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDespwn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "cloud"){
            Destroy(other.gameObject);
        }
    }
}
