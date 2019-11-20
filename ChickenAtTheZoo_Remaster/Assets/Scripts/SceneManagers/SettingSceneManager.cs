using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingSceneManager : MonoBehaviour
{
    public Slider soundBar;
    private float sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.Instance.getVolume();
        soundBar.value = sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainScene()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SoundManager.Instance.setVolume(soundBar.value);
        SceneManager.LoadScene("mainMenuScene");
    }
}
