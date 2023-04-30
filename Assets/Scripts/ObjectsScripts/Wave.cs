using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float deltaX = 0.0f;
    void Start()
    {
        Time.timeScale = 0;
    }

    void FixedUpdate()
    {
        Time.timeScale = 1;
        deltaX += Time.smoothDeltaTime;
        this.transform.Translate(Vector3.up * Mathf.Sin(deltaX * 7) * 0.02f);
    }
}
