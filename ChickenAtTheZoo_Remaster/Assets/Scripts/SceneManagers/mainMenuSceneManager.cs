using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuSceneManager : MonoBehaviour
{
    public Button gameStartButton;
    public Button mapEditButton;
    public Button settingButton;

    public Sprite GSB;
    public Sprite MEB;
    public Sprite SB;

    public void GameStartButton()
    {
        SceneManager.LoadScene("selectStageScene");
    }

    public void MapEditButton()
    {
        
    }

    public void SettingButton()
    {
    }
    public void GameStartButtonDown()
    {
        gameStartButton.image.sprite = GSB;
    }

    public void MapEditButtonDown()
    {
        mapEditButton.image.sprite = MEB;

    }

    public void SettingButtonDown()
    {
        settingButton.image.sprite = SB;
    }
}
