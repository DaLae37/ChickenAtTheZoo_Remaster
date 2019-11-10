using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public Sprite[] playerSprites = new Sprite[4];
    private Rigidbody2D rb;

    private bool isSelected;
    private bool isJump;
    private bool isLeft;
    private bool usedSkill;

    public int jumpLength = 5;
    public int moveSpeed = 3;
    private int characterType;//1 = double jump, 2 = rock, 3 = strecth, 4 = reverse

    // Start is called before the first frame update
    private void Start()
    {
        //Initialization
        isSelected = false;
        isJump = false;
        isLeft = false;
        usedSkill = false;

        characterType = Convert.ToInt32(gameObject.name.Split('r')[1]);
        rb = GetComponent<Rigidbody2D>();

        //The Player must have a name such as "Player*", so locate the object name and set the sprite.
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[characterType - 1];
    }

    // Update is called once per frame
    private void Update()
    {
        if (isSelected)
        {
            Move();
        }
    }

    private void Move()
    {
#if UNITY_EDITOR
        if (Input.anyKeyDown && usedSkill)
        {
            ReleasingSkill();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SideMoving(true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SideMoving(false);
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isJump)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Q) && !usedSkill)
        {
            UsingSkill();
        }
#endif
#if UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {

                }
            }

        }
#endif
    }

    public void SideMoving(bool isLeft)
    {
        if (this.isLeft != isLeft)
        {
            this.isLeft = isLeft;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
    }

    public void Jump()
    {
        isJump = true;
        rb.velocity = new Vector3(0, jumpLength, 0);
    }

    public void UsingSkill()
    {
        usedSkill = true;
        switch (characterType)
        {
            case 1:
                Jump();
                break;
            case 2:
                rb.velocity = new Vector3(0, 0, 0);
                rb.gravityScale = 0;
                break;
            case 3:
                break;
        }
    }

    public void ReleasingSkill()
    {
        usedSkill = isJump;
        switch (characterType)
        {
            case 2:
                rb.gravityScale = 1;
                break;
            case 3:
                break;
        }
    }

    public void setIsSelected(bool isSelected)
    {
        this.isSelected = isSelected;
    }

    public bool getIsSelected()
    {
        return isSelected;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isJump = false;
        }
    }    
}
