using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClousSpawner : MonoBehaviour
{
    public GameObject[] clouds;
    public float height = 5f;
    Vector2 cloudPosition;
    public float interval = 10f; 

    private void Start() {
        StartCoroutine(SpawnCloud());        
    }

    IEnumerator SpawnCloud(){
        while(true){
            cloudPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-height, height));
            Instantiate(clouds[Random.Range(0,2)], cloudPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(interval, interval + 5f));
        }
        
    }
}
