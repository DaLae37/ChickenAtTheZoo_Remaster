using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    float endPointY;
    float startPointY;
    bool isUp;


    void Start()
    {
        startPointY = transform.position.y;
        endPointY = gameObject.transform.GetChild(0).transform.position.y;
        isUp = true;
    }

    void FixedUpdate()
    {
        if (isUp)
        {
            transform.Translate(Vector3.up * 2.0f * Time.deltaTime);
            if (transform.position.y > endPointY)
                isUp = false;
        }
        else
        {
            transform.Translate(Vector3.up * -2.0f * Time.deltaTime);
            if (transform.position.y < startPointY)
                isUp = true;
        }
    }

}
