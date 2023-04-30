using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    public GameObject endPos;
    public GameObject startPos;
    private bool isMoving;
    private bool isRight;
    private float speed;

    public Sprite eating;
    public Sprite swimming;

    private float eatingTimer;


    void Start()
    {
        speed = 2.5f;
        isRight = true;
        isMoving = true;
        eatingTimer = 0;
    }

    void Update()
    {
        if (eatingTimer > 4f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = eating;
            gameObject.tag = "Enemy";
        }
        if (eatingTimer > 8f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = swimming;
            gameObject.tag = "Ground";
            eatingTimer = 0;
        }
        eatingTimer += Time.deltaTime;


        if (isRight && isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos.transform.position, speed * Time.deltaTime);
        }
        if (!isRight && isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos.transform.position, speed * Time.deltaTime);
        }


        if (isRight && Mathf.Abs(transform.position.x - endPos.transform.position.x) < 0.1f)
        {
            isRight = false;
            RotateSprite();
        }
        if ((!isRight) && Mathf.Abs(transform.position.x - startPos.transform.position.x) < 0.1f)
        {
            isRight = true;
            RotateSprite();
        }
    }

    void RotateSprite()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
