using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip start_main_BGM;
    public AudioClip buttonClick;
    public AudioClip characterChange;
    public AudioClip characterDead;
    public AudioClip openDoor;
    public AudioClip collisionGround;
    public AudioClip jump;
    public AudioClip lionDead;
    public AudioClip portal;
    public AudioClip skill;
    public AudioClip start;
    public AudioClip stone;
    public AudioClip water;

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;

                if (instance == null)
                {
                    Debug.LogError("SoundManager is not exist in this game");
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBackgroundSound(string soundName, bool isLoop)
    {
        audioSource.Stop();
        audioSource.clip = Soundlist(soundName);
        audioSource.loop = isLoop;
        audioSource.time = 0f;
        audioSource.Play();
    }

    public void PlayEffectSound(string soundName)
    {
        audioSource.PlayOneShot(Soundlist(soundName));
    }

    public void setVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public float getVolume()
    {
        return audioSource.volume;
    }

    private AudioClip Soundlist(string soundName)
    {
        AudioClip findedSound;

        switch (soundName)
        {
            case "start_main_BGM":
                findedSound = start_main_BGM;
                break;
            case "buttonClick" :
                findedSound = buttonClick;
                break;
            case "characterChange":
                findedSound = characterChange;
                break;
            case "characterDead":
                findedSound = characterDead;
                break;
            case "openDoor":
                findedSound = openDoor;
                break;
            case "collisionGround":
                findedSound = collisionGround;
                break;
            case "jump":
                findedSound = jump;
                break;
            case "lionDead":
                findedSound = lionDead;
                break;
            case "portal":
                findedSound = portal;
                break;
            case "skill":
                findedSound = skill;
                break;
            case "start":
                findedSound = start;
                break;
            case "stone":
                findedSound = stone;
                break;
            case "water":
                findedSound = water;
                break;
            default:
                findedSound = characterChange;
                break;
        }
        return findedSound;
    }
}