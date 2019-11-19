using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public GameObject endPos;
    public GameObject startPos;
    private bool isMoving;
    private bool isRight;
    private float speed;
    

    void Start()
    {
        speed = 2.5f;
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight&&isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos.transform.position, speed * Time.deltaTime);
        }
        if (!isRight && isMoving){
            transform.position = Vector2.MoveTowards(transform.position, startPos.transform.position, speed * Time.deltaTime);
        }


        if (isRight&& Mathf.Abs(transform.position.x-endPos.transform.position.x)<0.1f)
        {
            isRight = false;
            isMoving = false;
        }
        if ((!isRight)&& Mathf.Abs(transform.position.x - startPos.transform.position.x) < 0.1f)
        {
            isRight = true;
            isMoving = false;
        }
    }

    void RotateSprite()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string colTag = collision.gameObject.tag;
        if(colTag == "Player" && !isMoving && collision.transform.position.y>transform.position.y+0.9f)
        {
            RotateSprite();
            isMoving = true;
        }
    }
}
