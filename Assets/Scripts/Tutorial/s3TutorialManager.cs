using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s3TutorialManager : MonoBehaviour
{
    public GameObject[] tutPoint = new GameObject[3];
    public Text[] text = new Text[3];


    private storyPoints[] sP = new storyPoints[3];
    private float timer;
    private int idx;

    private void Awake()
    {
        timer = 0;
        idx = 0;

        for (int i = 0; i < 3; i++)
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

        if (sP[0].GetIsTr() && idx == 0)
        {
            text[0].gameObject.SetActive(true);
            idx++;
            timer += 0.1f;
        }
        if (timer > 3.0f && idx == 1)
        {
            text[0].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
        if (sP[1].GetIsTr() && idx == 2)
        {
            text[1].gameObject.SetActive(true);
            idx++;
            timer += 0.1f;
        }
        if (timer > 3.0f && idx == 3)
        {
            text[1].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
        if (sP[2].GetIsTr() && idx == 4)
        {
            text[2].gameObject.SetActive(true);
            idx++;
            timer += 0.1f;
        }
        if (timer > 3.0f && idx == 5)
        {
            text[2].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }

    }
}
