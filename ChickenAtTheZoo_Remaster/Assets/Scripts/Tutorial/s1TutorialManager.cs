using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class s1TutorialManager : MonoBehaviour
{
    public GameObject[] tutPoint = new GameObject[2];
    public Text[] text = new Text[3];


    private storyPoints[] sP = new storyPoints[2];
    private float timer;
    private int idx;
    private bool c3chk1;
    private bool c3chk2;

    private void Awake()
    {
        timer = 0.1f;
        idx = 0;
        c3chk1 = false;
        c3chk2 = false;

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

        if (timer > 0.5f && idx ==0)
        {
            text[0].gameObject.SetActive(true);
            timer = 0.1f;
            idx++;
        }

        if (sP[0].GetIsTr())
        {
            c3chk1 = true;
        }
        if (sP[1].GetIsTr())
        {
            c3chk2 = true;
        }
        if (timer > 3f && idx == 1)
        {
            text[0].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
        if (idx == 2 && c3chk1)
        {
            timer += 0.1f;
            text[1].gameObject.SetActive(true);
            idx++;
        }
        if (timer > 3f && idx == 3)
        {
            text[1].gameObject.SetActive(false);
            idx++;
            timer = 0;
        }
        if (idx == 4 && c3chk2)
        {
            text[2].gameObject.SetActive(true);
            idx++;
        }
    }
    
}
