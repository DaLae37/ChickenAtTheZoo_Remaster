using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxControl : MonoBehaviour
{
    public GameObject box;


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(box.transform.position.x, box.transform.position.y, -10), Time.deltaTime * 5.0f);
    }
}
