using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemy : MonoBehaviour
{
    public float speed = 0.5f;
    public float height = 1f;
    float originalY;

    public Sprite[] masks;
    int maskNum;


    // Start is called before the first frame update
    void Start()
    {
        this.originalY = this.transform.position.y;

        maskNum = Random.Range(0, 6);
        transform.GetComponent<SpriteRenderer>().sprite = masks[maskNum];

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, originalY + (Mathf.Sin(Time.time * speed) * height));

        
    }
}
