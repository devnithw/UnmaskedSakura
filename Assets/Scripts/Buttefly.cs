using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttefly : MonoBehaviour
{
    public  float boundsX = 5;
    public float boundsY = 5;
    public float speed = 1;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(transform.position.x + Random.Range(-boundsX, boundsX), transform.position.y + Random.Range(-boundsY, boundsY));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pos) < 0.01f){
            pos = new Vector2(transform.position.x + Random.Range(-boundsX, boundsX), transform.position.y + Random.Range(-boundsY, boundsY));
        } else {
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        }   
        
    }
}
