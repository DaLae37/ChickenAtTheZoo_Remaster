using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMakeSceneManager : MonoBehaviour
{
    public GameObject block;
    private string map;
    private int[,] mapArray = new int[10, 25];
    public Sprite[] sprites = new Sprite[21];
    // Start is called before the first frame update
    void Start()
    {
        map = PlayerPrefs.GetString("MapMakeScene");
        
        string[] tmps = map.Split('@');
        int loopNum = 0;
        for(int i=0; i<25; i++)
        {
            for(int j=0; j<10; j++)
            {
                mapArray[j,i] = Convert.ToInt32(tmps[loopNum++]);
            }
        }
        for(int i=0; i<10; i++)
        {
            for(int j=0; j<25; j++)
            {
                GameObject g = new GameObject();
                g.AddComponent<SpriteRenderer>().sprite = sprites[mapArray[i, j]];
                g.transform.position = new Vector2(-10 + j, 5 - i);
                g.transform.SetParent(block.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainScene()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("MapEditScene");
    }
}
