using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelectManager : MonoBehaviour
{



    public void Tutorial1()
    {
        SceneManager.LoadScene("tutorial1");
    }
    public void Tutorial2()
    {
        SceneManager.LoadScene("tutorial2");
    }
    public void Stage1()
    {
        SceneManager.LoadScene("stage1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("stage3");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("stage4");
    }
}
