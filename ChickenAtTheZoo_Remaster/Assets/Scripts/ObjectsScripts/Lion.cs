using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour
{

    public GameObject deadLion;
    public float speed;
    private float timer;
    private bool isLeft;

    private int life;

    void Start()
    {
        timer = 0;
        isLeft = false;

        if (gameObject.name == "boss")
            life = 3;
        else
            life = 1;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 4f)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            timer = 0;
        }
        transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;
        if (collTag == "Stone")
        {
            if (collision.transform.position.y > transform.position.y)
            {
                Destroy(collision.gameObject);
                life--;
                if (life == 0)
                {
                    Destroy(gameObject);
                    if (gameObject.name == "boss")
                    {
                        GameObject go = deadLion;
                        go.transform.localScale = new Vector3(3, 3, 1);
                        Instantiate(go, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        GameObject go = deadLion;
                        go.transform.localScale = new Vector3(1, 1, 1); ;
                        Instantiate(go, transform.position, Quaternion.identity);
                    }
                }
            
            }
        }
    }
}
