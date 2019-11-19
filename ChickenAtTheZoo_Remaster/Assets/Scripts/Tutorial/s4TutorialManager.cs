using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s4TutorialManager : MonoBehaviour
{
    public GameObject[] tutPoint = new GameObject[1];
    public Text[] text = new Text[2];


    private storyPoints[] sP = new storyPoints[1];
    private float timer;
    private int idx;

    private void Awake()
    {
        timer = 0.1f;
        idx = 0;

        sP[0] = tutPoint[0].GetComponent<storyPoints>();
        for (int i = 0; i < 2; i++)
        {
            text[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (timer > 0)
            timer += Time.deltaTime;

        if (timer>0.5f && idx == 0)
        {
            text[0].gameObject.SetActive(true);
            idx++;
            timer = 0.1f;
        }
        if (timer > 4.0f && idx == 1)
        {
            text[0].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
        if (sP[0].GetIsTr()&& idx == 2)
        {
            text[1].gameObject.SetActive(true);
            idx++;
            timer += 0.1f;
        }
        if (timer > 4.0f && idx == 3)
        {
            text[1].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
    }
}
