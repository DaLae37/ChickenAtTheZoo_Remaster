using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelectManager : MonoBehaviour
{



    public void Tutorial1()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("tutorial1");
    }
    public void Tutorial2()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("tutorial2");
    }
    public void Stage1()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("stage1");
    }
    public void Stage2()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("stage2");
    }
    public void Stage3()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("stage3");
    }

    public void Stage4()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("stage4");
    }

    public void MainScene()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("mainMenuScene");
    }
}
