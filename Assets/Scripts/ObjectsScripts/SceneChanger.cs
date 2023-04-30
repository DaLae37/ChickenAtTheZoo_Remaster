using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    GameObject clearPanel;
    Button nextButton;
    Button stageButton;

    public Sprite nB;
    public Sprite sB;

    private void Start()
    {
        clearPanel = GameObject.Find("clearPanel");
        nextButton = GameObject.Find("nextButton").GetComponent<Button>();
        stageButton = GameObject.Find("stageButton").GetComponent<Button>();

        clearPanel.SetActive(false);
    }

    public void NextButton()
    {
        nextButton.image.sprite = nB;
    }
    public void StageButton()
    {
        stageButton.image.sprite = sB;
    }
    
    public void StageButtonDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("selectStageScene");
    }

    public void ChangeScene()
    {
        Time.timeScale = 1;
        switch (SceneManager.GetActiveScene().name)
        {
            case "tutorial1":
                SceneManager.LoadScene("tutorial2");
                break;
            case "tutorial2":
                SceneManager.LoadScene("stage1");
                break;
            case "stage1":
                SceneManager.LoadScene("stage2");
                break;
            case "stage2":
                SceneManager.LoadScene("stage3");
                break;
            case "stage3":
                SceneManager.LoadScene("stage4");
                break;
            case "stage4":
                SceneManager.LoadScene("mainMenuScene");
                break;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;
        if (collTag.Equals("Player"))
        {
            SoundManager.Instance.PlayEffectSound("portal");
            Time.timeScale = 0;
            clearPanel.SetActive(true);

        }
    }

}
