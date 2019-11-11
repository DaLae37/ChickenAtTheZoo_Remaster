using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public Sprite[] playerSprites = new Sprite[4];
    public GameObject addCharacterObject;
    public GameObject addCharacters;
    private Rigidbody2D rb;

    private bool isSelected;
    private bool isJump;
    private bool isLeft;
    private bool usedSkill;
    private bool onNest;

    public int maxAddCharacterCount = 5;
    public int jumpLength = 5;
    public int moveSpeed = 3;
    private int characterType;//1 = double jump, 2 = rock, 3 = strecth, 4 = reverse
    private int addCharacterCount;

    float addCharacterTimer; //3전용

    // Start is called before the first frame update
    private void Start()
    {
        //Initialization
        isSelected = false;
        isJump = false;
        isLeft = false;
        usedSkill = false;
        onNest = false;

        addCharacterCount = 0;

        addCharacterTimer = 0f;

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
        if(Input.GetKeyUp(KeyCode.Q) && characterType == 3)
        {
            usedSkill = true;
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
        switch (characterType)
        {
            case 1:
                Jump();
                usedSkill = true;
                break;
            case 2:
                rb.velocity = new Vector3(0, 0, 0);
                rb.gravityScale = 0;
                usedSkill = true;
                break;
            case 3:
                if (onNest)
                {
                    addCharacterTimer += Time.deltaTime;
                    rb.gravityScale = 0;

                    if (addCharacterTimer >= 1) //1초마다 1개
                    {
                        addCharacterCount += 1;
                        if (addCharacterCount <= maxAddCharacterCount) //5개 최대
                        {
                            addCharacterTimer -= 1;
                            GameObject g = Instantiate(addCharacterObject); //addCharacters 자식등록
                            g.transform.position = transform.position;
                            g.transform.rotation = transform.rotation;
                            g.transform.SetParent(addCharacters.transform);
                            float characterAddPosX = 0.75f;
                            if (isLeft)
                                characterAddPosX *= -1;
                            transform.position = new Vector3(transform.position.x + characterAddPosX, transform.position.y, transform.position.z);
                        }
                    }
                }
                break;
        }
    }

    public void ReleasingSkill()
    {
        usedSkill = isJump;
        rb.gravityScale = 1;
        switch (characterType)
        {
            case 3:
                DestroyChild();
                break;
        }
    }

    public void DestroyChild() //addCharacter 다 지우기
    {
        addCharacterCount = 0;
        addCharacterTimer = 0f;
        for (int i = 0; i < addCharacters.transform.childCount; i++)
        {
            if(usedSkill && i == addCharacters.transform.childCount - 1) //원래로 돌아오게하려면 i == 0,
            {
                transform.position = addCharacters.transform.GetChild(i).transform.position;
            }
            Destroy(addCharacters.transform.GetChild(i).gameObject);
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
        string collTag = collision.gameObject.tag;
        if (collTag.Equals("Ground") || collTag.Equals("Player") || collTag.Equals("Nest"))
        {
            isJump = false;
            if (collTag.Equals("Nest"))
                onNest = true;
            else
                onNest = false;
        }
    }
}
