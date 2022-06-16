using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject[] grounds;
    public GameObject[] trees;
    public SpriteRenderer background;
    int num;
    Color[] backgroundColors =  { new Color32(255,112,0,255), new Color32(108,255,208,255), new Color32(168,0,224,255)};

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0,3);
        grounds[num].SetActive(true);
        trees[num].SetActive(true);
        background.color = backgroundColors[num];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
