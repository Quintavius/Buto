using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public AudioSource themeSource;
    public AudioSource efxSource;

    public AudioClip Buto;
    public AudioClip Peace; // change
    public AudioClip Kabu; // change
    public AudioClip Joy;

    public AudioClip[] soundEffects;


    private AudioClip selectedTheme;
    //public AudioClip[] starClicks;

    public static SoundManager instance = null;

    // Use this for initialization
    void Awake()
    {
        efxSource = GameObject.Find("Sound Effects Manager").GetComponent<AudioSource>();
        themeSource = GameObject.Find("Sound Manager").GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "AnneMainMenu" || SceneManager.GetActiveScene().name == "NewMainMenu")
        {
            selectedTheme = Buto;
        }
        themeSource.clip = selectedTheme;
        themeSource.Play();

        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void PlayTheme(string themeName)
    {
        AudioClip selectedTheme = (AudioClip)this.GetType().GetField(themeName).GetValue(this);
        themeSource.clip = selectedTheme;
        themeSource.Play();
    }

    public void PlaySound(string clipName)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].name == clipName)
            {
                efxSource.PlayOneShot(soundEffects[i]);
            }
        }

    }
}
