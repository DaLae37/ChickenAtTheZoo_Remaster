using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    private const int widthRatio = 19;
    private const int heightRatio = 9;
    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width *  heightRatio / widthRatio, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBackgroundSound("start_main_BGM", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("mainMenuScene");
        }
        
    }

}
 