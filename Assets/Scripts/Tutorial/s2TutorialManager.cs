using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s2TutorialManager : MonoBehaviour
{
    public GameObject[] tutPoint = new GameObject[2];
    public Text[] text = new Text[2];


    private storyPoints[] sP = new storyPoints[2];
    private float timer;
    private int idx;

    private void Awake()
    {
        timer = 0;
        idx = 0;

        for (int i = 0; i < 2; i++)
        {
            sP[i] = tutPoint[i].GetComponent<storyPoints>();
        }
        for (int i = 0; i < 2; i++)
        {
            text[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (timer > 0)
            timer += Time.deltaTime;

        if (sP[0].GetIsTr() && idx == 0)
        {
            text[0].gameObject.SetActive(true);
            idx++;
        }
        if (sP[1].colName == "Player1"&&idx==1)
        {
            text[1].gameObject.SetActive(true);
            timer += 0.1f;
            idx++;
        }
        if (timer > 4.0f && idx == 2)
        {
            text[1].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }

    }
}
