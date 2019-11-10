using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player[] players = new Player[4];
    private int playerIndex;
    private int playerMaxIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject []tmp = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0; i<tmp.Length; i++)
        {
            players[i] = tmp[i].GetComponent<Player>();
        }
        playerMaxIndex = tmp.Length;
    }

    // Update is called once per frame
    void Update()
    {
        players[0].setIsSelected(true);
    }

    public void PlayerChange()
    {
        players[playerIndex].setIsSelected(false);
        playerIndex++;
        if(playerMaxIndex == players.Length)
        {
            players[playerIndex].setIsSelected(true);
            playerIndex = 0;
        }
    }
}
