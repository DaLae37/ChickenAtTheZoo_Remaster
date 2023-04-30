using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t2TutorialManager : MonoBehaviour
{
    public GameObject[] tutPoint = new GameObject[2];
    public Text[] text = new Text[3];


    private storyPoints[] sP = new storyPoints[2];
    private float timer;
    private int idx;

    private void Awake()
    {
        timer = 0.1f;
        idx = 0;
        for (int i = 0; i < 2; i++)
        {
            sP[i] = tutPoint[i].GetComponent<storyPoints>();
        }
        for (int i = 0; i < 3; i++)
        {
            text[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (timer > 0)
            timer += Time.deltaTime;

        if(timer > 0.5f && idx==0)
        {
            text[0].gameObject.SetActive(true);
            timer = 0;
            idx++;
        }

        if (sP[0].GetIsTr())
        {
            text[0].gameObject.SetActive(false);
        }


        if (sP[1].GetIsTr() && idx == 1)
        {
            text[1].gameObject.SetActive(true);
            timer += 0.1f;
            idx++;
        }

        if (timer > 3.0f && idx == 2)
        {
            text[1].gameObject.SetActive(false);
            text[2].gameObject.SetActive(true);
            idx++;
        }
        if (timer > 7.0f && idx == 3)
        {

            text[2].gameObject.SetActive(false);
            timer = 0;
        }

        
    }
}
