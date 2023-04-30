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
        SceneManager.LoadScene("MapEditScene");
    }

    public void SettingButton()
    {
        SceneManager.LoadScene("settingScene");
    }
    public void GameStartButtonDown()
    {
        gameStartButton.image.sprite = GSB;
        SoundManager.Instance.PlayEffectSound("buttonClick");
    }

    public void MapEditButtonDown()
    {
        mapEditButton.image.sprite = MEB;
        SoundManager.Instance.PlayEffectSound("buttonClick");
    }

    public void SettingButtonDown()
    {
        settingButton.image.sprite = SB;
        SoundManager.Instance.PlayEffectSound("buttonClick");
    }
}
