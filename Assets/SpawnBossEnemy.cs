using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    public float interval = 5f;
    public Animator animator;
    bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle_follow_player") && !spawning){
            StartCoroutine(SpawnEnemies(2));
            spawning = true;
        } else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle_follow_player") && spawning){
            spawning = false;
        }
        
    }

    private IEnumerator SpawnEnemies(int num){
        for (int i = 0; i < num; i++)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }

    }
}
