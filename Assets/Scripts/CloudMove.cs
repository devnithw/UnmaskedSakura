using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    float moveSpeed;
    public int moveSpeedMultiplier = 1;
    Vector3 scale;
    float scaleMultiplier;
    SpriteRenderer sp_renderer;
    Color tmp_color;
    
    private void Start() {
        moveSpeed = Random.Range(0.1f, 1f) * moveSpeedMultiplier;
        scale = transform.localScale;
        scaleMultiplier = Random.Range(0.5f,1f);
        scale.x *= scaleMultiplier;
        scale.y *= scaleMultiplier;
        transform.localScale = scale;
        sp_renderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        
    }
}
