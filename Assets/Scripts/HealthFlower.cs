using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlower : MonoBehaviour
{
    public PlayerHealth healthScript;
    public ParticleSystem particlesNormal;
    public ParticleSystem particlesBurst;
    public int numOfHearts = 1;
    public AudioSource sfx;
    float originalY;
    public float speed = 0.5f;
    public float height = 1f;
    public bool bobbing = true;

    private void Awake() {
        particlesBurst.Stop();
        this.originalY = this.transform.position.y;

    }
    
    private void Update() {
        if (bobbing){
            transform.position = new Vector2(transform.position.x, originalY + (Mathf.Sin(Time.time * speed) * height));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player"){
            Destroy(transform.GetComponent<CircleCollider2D>());
            Destroy(particlesNormal);
            healthScript = other.GetComponent<PlayerHealth>();
            healthScript.Heal(numOfHearts);
            particlesBurst.Play();
            particlesBurst.Emit(20);
            transform.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            Destroy(transform.gameObject, 1.5f);
            sfx.Play();

        }

        
    }
}
