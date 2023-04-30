using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Sprite[] playerSprites = new Sprite[4];
    public GameObject addCharacterObject;
    public GameObject addCharacters;
    private Rigidbody2D rb;
    private Animator ani;


    private bool isSelected;
    private bool isJump;
    private bool isLeft;
    private bool usedSkill;
    private bool onNest;
    private bool isDead;

   // private bool doubleTouch;
   // private bool doubleToOne; //더블 터치에서 하나로 간거 판별
    private bool isAnimation; //애니메이션 실행중

    //버튼 이동 부분
    private bool leftChk;
    private bool rightChk;
    private bool strecthChk;
    private bool isStrecthed;

    //


    public int maxAddCharacterCount = 5;
    public float jumpLength = 5;
    public int moveSpeed = 3;
    private int characterType;//1 = strecth, 2 = double jump, 3 = rock, 4 = reverse
    private int addCharacterCount;

    float addCharacterTimer; //1전용
    float strecthTime; //1 스킬 사용 시간
   // private float doubleTouchTimer; //더블 터치 전용

    // Start is called before the first frame update
    private void Start()
    {
        //Initialization
        isSelected = false;
        isJump = false;
        isLeft = false;
        usedSkill = false;
        onNest = false;
        strecthChk = false;
        isStrecthed = false;

        leftChk = false;
        rightChk = false;
        isAnimation = false;
        isDead = false;


        addCharacterCount = 0;

        addCharacterTimer = 0f;

        strecthTime = 0.5f;

        characterType = Convert.ToInt32(gameObject.name.Split('r')[1]);
        rb = GetComponent<Rigidbody2D>();        

        //The Player must have a name such as "Player*", so locate the object name and set the sprite.
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[characterType - 1];

        ani = GetComponent<Animator>();
        ani.speed = 0;
    }

    private void FixedUpdate()
    {
        if (isSelected)
        {
            if (!isAnimation && !usedSkill)
            {
                ani.speed = 1;
                isAnimation = true;
            }
            if (strecthChk)
            {
                UsingSkill();
            }

            Move();

        }
        else
        {
            if (isAnimation)
            {
                ani.speed = 0;
                isAnimation = false;
            }
        }

    }

    private void Move()
    {

        if (leftChk == true)
            SideMoving(true);
        if (rightChk == true)
            SideMoving(false);

#if UNITY_EDITOR
        if (Input.anyKeyDown && usedSkill && !Input.GetMouseButtonDown(0))
        {
            ReleasingSkill();
        }
        if (!(Input.GetKey(KeyCode.Q) && onNest))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SideMoving(true);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                SideMoving(false);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)&&!isJump)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Q)&&!usedSkill)
        {
            UsingSkill();
        }
        if(Input.GetKeyUp(KeyCode.Q) && characterType == 1)
        {
            usedSkill = true;
        }
#endif
#if UNITY_ANDROID

        /*

        if (Input.touchCount == 1)
        {
            if (EventSystem.current.IsPointerOverGameObject(0) == false)
            {
                if (Input.touchCount > 0 && usedSkill)
                    ReleasingSkill();

                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = touch.position;

                if (!isStrecth)
                {
                    if (touch.phase != TouchPhase.Ended)
                    {
                        if (touchPos.x < Screen.width / 2)
                            SideMoving(true);
                        else
                            SideMoving(false);
                    }
                }
                if (characterType == 3 && touch.phase == TouchPhase.Ended && isJump && !usedSkill)
                {
                    UsingSkill();

                }

            }
        
        }
        if (Input.touchCount == 2)
        {
            if (EventSystem.current.IsPointerOverGameObject(0) == false && EventSystem.current.IsPointerOverGameObject(1) == false)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch2.phase != TouchPhase.Ended && characterType == 1 && onNest && usedSkill == false)
                {
                    UsingSkill();
                }
                else if (touch2.phase == TouchPhase.Began && isJump == false)
                {
                    Jump();
                }
                else if (touch2.phase == TouchPhase.Began && isJump == true && usedSkill == false)
                {
                    UsingSkill();
                }

                if ((touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended) && characterType == 1)
                {
                    usedSkill = true;
                }

            }
        }
        */

        //if (Input.touchCount > 0 && usedSkill)
        //{
        //    ReleasingSkill();
        //}
        //if (Input.touchCount == 1)
        //{
        //    if (EventSystem.current.IsPointerOverGameObject(0) == false)
        //    {
        //        doubleTouchTimer += Time.deltaTime;
        //        Touch touch = Input.GetTouch(0);
        //        Vector2 touchPos = touch.position;
        //        if (touch.phase != TouchPhase.Ended)
        //        {
        //            if (touchPos.x < Screen.width / 2)
        //            {
        //                SideMoving(true);
        //            }
        //            else
        //            {
        //                SideMoving(false);
        //            }
        //        }
        //        if (doubleToOne && characterType != 1)
        //        {
        //            usedSkill = true;
        //            doubleToOne = false;
        //            doubleTouch = false;
        //        }
        //    }
        //}
        //else if (Input.touchCount == 2)
        //{
        //    doubleToOne = true;
        //    if (EventSystem.current.IsPointerOverGameObject(0) == false && EventSystem.current.IsPointerOverGameObject(1) == false)
        //    {
        //        Touch touch1 = Input.GetTouch(0);
        //        Touch touch2 = Input.GetTouch(1);
        //        if (doubleTouchTimer < 0.1f)
        //        {
        //            if (touch2.phase == TouchPhase.Began)
        //            {
        //                doubleTouchTimer = 0f;
        //                doubleTouch = true;
        //            }
        //        }
        //        else
        //        {
        //            doubleTouchTimer = 0f;
        //        }
        //        if (!doubleTouch)
        //        {
        //            Vector3 touchPos1 = touch1.position;
        //            Vector3 touchPos2 = touch2.position;
        //            if ((touchPos1.x < Screen.width / 2) && (touchPos2.x >= Screen.width / 2))
        //            {
        //                SideMoving(true);
        //                if (!isJump && (touch2.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began))
        //                    Jump();
        //            }
        //            else if (((touchPos1.x >= Screen.width / 2) && (touchPos2.x < Screen.width / 2)))
        //            {
        //                SideMoving(false);
        //                if (!isJump && (touch2.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began))
        //                    Jump();
        //            }
        //        }
        //        else
        //        {
        //            if (!usedSkill)
        //                UsingSkill();
        //        }
        //    }
        //}
#endif
    }

    public void SideMoving(bool isLeft)
    {
        if (characterType != 4)
        {
            if (this.isLeft != isLeft)
            {
                this.isLeft = isLeft;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        }
        else
        {
            if (this.isLeft == isLeft)
            {
                this.isLeft = !isLeft;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);

        }
    }

    public void Jump()
    {
        isJump = true;
        if (characterType != 4)
        {
            rb.velocity = new Vector3(0, jumpLength, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -jumpLength, 0);

        }

    }


   
    public void UsingSkill()
    {

        if (characterType == 1)
        {

            ani.speed = 0;
            addCharacterTimer += Time.deltaTime;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            if (addCharacterTimer >= strecthTime) //t초마다 1개
            {
                addCharacterCount += 1;
                if (addCharacterCount <= maxAddCharacterCount) //최대
                {
                    addCharacterTimer -= strecthTime;
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

        if (!usedSkill)
        {
            switch (characterType)
            {
                case 2:
                    Jump();
                    usedSkill = true;
                    break;
                case 3:
                    ani.speed = 0;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.gravityScale = 0;
                    rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    usedSkill = true;
                    break;
            }
        }
    }

    public void ReleasingSkill()
    {
        usedSkill = isJump;
        ani.speed = 1;
        switch (characterType)
        {
            case 1 :
                DestroyChild();
                onNest = false;
                isStrecthed = false;
                rb.gravityScale = 1;
                rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                break;
            case 3:
                rb.gravityScale = 1;
                rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                break;

        }
    }

    public void DestroyChild() //addCharacter 다 지우기
    {
        addCharacterCount = 0;
        addCharacterTimer = 0f;
        for (int i = 0; i < addCharacters.transform.childCount; i++)
        {
            if(strecthChk && i == addCharacters.transform.childCount - 1) //원래로 돌아오게하려면 i == 0,
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

    public void LeftButtonDown()
    {
        if(!isStrecthed)   
            leftChk = true;
        if ((characterType == 1 && isStrecthed) || (characterType != 1 && usedSkill))
        {
            ReleasingSkill();

        }
    }
    public void LeftButtonUp()
    {
        leftChk = false;

    }
    public void RightButtonDown()
    {
        if (!isStrecthed)
            rightChk = true;
        if ((characterType == 1 && isStrecthed) || (characterType != 1 && usedSkill))
        {
            ReleasingSkill();

        }

    }
    public void RightButtonUp()
    {
        rightChk = false;

    }
    public void JumpButtonDown()
    {
        if (!isJump)
        {
            ReleasingSkill();
            Jump();
        }
    }

    public void SkillButtonDown()
    {
        if (characterType == 1)
        {
            strecthChk = true;
            isStrecthed = true;
        }
        else if (!usedSkill)
        {
            UsingSkill();
        }

    }
    public void SkillButtonUp()
    {
        if (characterType == 1)
        {
            strecthChk = false;
        }

    }
    public bool GetIsJump()
    {

        return isJump;
    }
    public bool GetOnNest()
    {

        return onNest;
    }

    public bool GetIsStrecth()
    {

        return strecthChk;
    }

    public bool GetIsDead()
    {

        return isDead;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;

        if (collTag.Equals("Enemy"))
        {
            SoundManager.Instance.PlayEffectSound("characterDead");
            isDead = true;
        }

        if (collTag.Equals("Ground") || collTag.Equals("Player") || collTag.Equals("Button") || collTag.Equals("Nest"))
        {
            SoundManager.Instance.PlayEffectSound("collisionGround");
            isJump = false;

            if (usedSkill && collision.transform.name=="Player1" && isStrecthed)
            {
                ReleasingSkill();
            }
            else if (usedSkill && !collTag.Equals("Player"))
                ReleasingSkill();
        }
        if (collTag.Equals("Lion") && collision.contacts[0].collider.tag == "Ground")
        {
            isJump = false;
            if (usedSkill)
                ReleasingSkill();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;

        if (collTag.Equals("Nest"))
            onNest = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;

        if (collTag.Equals("Nest"))
            onNest = false;
    }
}
