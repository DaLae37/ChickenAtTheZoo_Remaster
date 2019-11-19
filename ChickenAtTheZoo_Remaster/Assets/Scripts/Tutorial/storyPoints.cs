using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyPoints : MonoBehaviour
{
    private bool isTr;
    public string colName;
    private void Awake()
    {
        colName = "";
        isTr = false;
    }
    public bool GetIsTr()
    {
        return isTr;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            colName = collision.transform.name;
            isTr = true;
        }
    }

}
