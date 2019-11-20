using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainCamera;

    private Player[] players = new Player[4];
    
    private int playerIndex;
    private int maxIndex;

    private bool jumpButtonMode;

    //시작체크
    private int startCnt;
    private bool tutorial;

    //UIs
    private GameObject[] changeButtons = new GameObject[4];
    GameObject jumpButton;
    GameObject skillButton;
    GameObject leftButton;
    GameObject rightButton;
    GameObject stopButton;
    GameObject stopPanel;

    //DiePanel
    GameObject diePanel;
    Button dieReButton;
    Button dieMenuButton;
    public Sprite RSB;
    public Sprite MB;


    // Start is called before the first frame update
    void Awake()
    {
        startCnt = 0;


        jumpButton = GameObject.Find("jumpButton");
        skillButton = GameObject.Find("skillButton");
        leftButton = GameObject.Find("leftButton");
        rightButton = GameObject.Find("rightButton");
        stopButton = GameObject.Find("stopButton");
        stopPanel = GameObject.Find("stopPanel");
        diePanel = GameObject.Find("diePanel");
        dieReButton = GameObject.Find("reStartButton").GetComponent<Button>();
        dieMenuButton = GameObject.Find("menuButton").GetComponent<Button>();

        skillButton.SetActive(false);
        stopPanel.SetActive(false);
        jumpButtonMode = true;
        diePanel.SetActive(false);

        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < tmp.Length; j++)
            {
                if (i == Convert.ToInt32(tmp[j].name.Split('r')[1]) - 1)
                    players[i] = tmp[j].GetComponent<Player>();

            }
        }
        maxIndex = tmp.Length;

        if (maxIndex == 1)
            tutorial = true;
        else
            tutorial = false;


        if (players[0] == null)
            playerIndex = 1;
        else if (players[0] == null && players[1] == null)
            playerIndex = 2;
        else
            playerIndex = 0;


        if (tutorial && (playerIndex == 1))
            changeButtons[0] = GameObject.Find("chick2Button");
        else
        {
            for (int i = 0; i < maxIndex; i++)
            {
                string name = "chick" + (i + 1).ToString() + "Button";
                changeButtons[i] = GameObject.Find(name);
            }
        }



    }
    private void Start()
    {
    }


    void Update()
    {


        if (players[playerIndex].GetIsDead())
        {
            StopGame();
            diePanel.SetActive(true);
        }

        if (startCnt == 0)
        {
            if(playerIndex==1)
                PlayerChange2();
            else
                PlayerChange1();
            startCnt++;
        }

        CameraFollowing();


        if (playerIndex != 0)
        {
            if (players[playerIndex].GetIsJump() && jumpButtonMode)
            {
                jumpButtonMode = false;
                jumpButton.SetActive(false);
                skillButton.SetActive(true);

            }
            else if (!players[playerIndex].GetIsJump() && !jumpButtonMode)
            {
                jumpButtonMode = true;
                jumpButton.SetActive(true);
                skillButton.SetActive(false);
            }
        }
        else
        {
            if (players[playerIndex].GetOnNest() && jumpButtonMode)
            {
                jumpButtonMode = false;
                jumpButton.SetActive(false);
                skillButton.SetActive(true);
            }
            else if (!players[playerIndex].GetOnNest() && !jumpButtonMode && !players[playerIndex].GetOnNest())
            {
                jumpButtonMode = true;
                jumpButton.SetActive(true);
                skillButton.SetActive(false);
            }
        }

    }

    public void PlayerChange1()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex=0;
        players[0].setIsSelected(true);
        if(!tutorial)
            ChangAlpha(0);

    }
    public void PlayerChange2()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 1;
        players[1].setIsSelected(true);
        if (!tutorial)
            ChangAlpha(1);
    }
    public void PlayerChange3()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 2;
        players[2].setIsSelected(true);
        if (!tutorial)
            ChangAlpha(2);
    }
    public void PlayerChange4()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 3;
        players[3].setIsSelected(true);
        if (!tutorial)
            ChangAlpha(3);
    }

    void ChangAlpha(int idx)
    {
    
        for (int i = 0; i < maxIndex; i++)
        {

            if (idx != i)
            {
                changeButtons[i].GetComponent<Button>().image.color = new Color(255, 255, 255, 0.5f);   
            }
        }
        changeButtons[idx].GetComponent<Button>().image.color = new Color(255, 255, 255, 1f);

    }


    public void LeftButtonDown()
    {
        players[playerIndex].LeftButtonDown();
    }
    public void LeftButtonUp()
    {
        players[playerIndex].LeftButtonUp();
    }
    public void RightButtonDown()
    {
        players[playerIndex].RightButtonDown();
    }
    public void RightButtonUp()
    {
        players[playerIndex].RightButtonUp();
    }
    public void JumpButtonDown()
    {
        players[playerIndex].JumpButtonDown();
    }
    public void SkillButtonDown()
    {
        players[playerIndex].SkillButtonDown();
    }
    public void SkillButtonUp()
    {
        players[playerIndex].SkillButtonUp();
    }

    public void StopButtonDown()
    {
        StopGame();
        stopPanel.SetActive(true);
    }
    public void StartButtonDown()
    {
        StartGame();
    }
    public void ReStartButtonDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoMenuButtonDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenuScene");
    }
    public void DieReStartButton()
    {
        dieReButton.image.sprite = RSB;
    }
    public void DieGoMenuButton()
    {
        dieMenuButton.image.sprite = MB;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        jumpButton.SetActive(false);
        skillButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        stopButton.SetActive(false);

        if(tutorial && playerIndex==1)
            changeButtons[0].SetActive(false);
        else
        {
            for (int i = 0; i < maxIndex; i++)
            {
                changeButtons[i].SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        if (jumpButtonMode)
            jumpButton.SetActive(true);
        else
            skillButton.SetActive(true);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        stopButton.SetActive(true);
        stopPanel.SetActive(false);
        if (tutorial && playerIndex == 1)
            changeButtons[0].SetActive(true);
        else
        {
            for (int i = 0; i < maxIndex; i++)
            {
                changeButtons[i].SetActive(true);
            }
        }
        
    }

    //camera targeting
    private void CameraFollowing()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(players[playerIndex].transform.position.x, players[playerIndex].transform.position.y,-10), Time.deltaTime * 5.0f);
    }
}
