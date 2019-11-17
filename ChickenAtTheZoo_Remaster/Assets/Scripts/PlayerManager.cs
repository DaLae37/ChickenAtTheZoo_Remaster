using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainCamera;

    private Player[] players = new Player[4];
    private int playerIndex;
    private int characterType;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject []tmp = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0; i<4; i++)
        {
            for (int j=0; j<tmp.Length; j++)
            {
                if(i== Convert.ToInt32(tmp[j].name.Split('r')[1])-1)
                    players[i] = tmp[j].GetComponent<Player>();

            }
        }
        if (players[0] == null)
            playerIndex = 1;
        else if (players[0] == null &&players[1] == null)
            playerIndex = 2;
        else
            playerIndex = 0;

    }


    void Update()
    {
        CameraFollowing();
    }

    public void PlayerChange1()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex=0;
        players[0].setIsSelected(true);
    }
    public void PlayerChange2()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 1;
        players[1].setIsSelected(true);
    }
    public void PlayerChange3()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 2;
        players[2].setIsSelected(true);
    }
    public void PlayerChange4()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex = 3;
        players[3].setIsSelected(true);
    }
    //camera targeting
    private void CameraFollowing()
    {
        
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(players[playerIndex].transform.position.x, players[playerIndex].transform.position.y,-10), Time.deltaTime * 5.0f);
    }
}
