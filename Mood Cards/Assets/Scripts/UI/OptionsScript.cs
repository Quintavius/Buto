using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

    private bool showMenu;
    private bool fullscreen;

    public GameObject OptionsPanel;
    public GameObject titleObject;

    public GameObject ResolutionMenu;
    public GameObject FullscreenToggle;
    public GameObject MusicSlider;
    public GameObject SoundEffectsSlider;

    private SoundManager soundManager;
    private SFXManager sfxManager;

    // Use this for initialization
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        sfxManager = FindObjectOfType<SFXManager>();

        InitialSettings();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ClearSaveData()
    {
        PlayerPrefs.DeleteAll();
        LastSceneHolder.LastSceneStatic = null;
    }

    public void OptionsButton()
    {
        if (OptionsPanel.activeInHierarchy)
        {
            OptionsPanel.SetActive(false);
            titleObject.SetActive(true);
        }
        else
        {
            OptionsPanel.SetActive(true);
            titleObject.SetActive(false);
        }
    }

    void InitialSettings()
    {
        // Fullscreen
        if (PlayerPrefs.GetString("Fullscreen") == "True")
        {
            fullscreen = true;
        }
        else
        {
            fullscreen = false;
        }

        fullscreen = Screen.fullScreen;
        FullscreenToggle.GetComponent<Toggle>().isOn = fullscreen;

        // Resolution
        if (Screen.currentResolution.ToString() == "1280 x 720")
        {
            ResolutionMenu.GetComponent<Dropdown>().value = 0;
            GameObject.Find("Resolution").GetComponent<Text>().text = "720p";
        }
        else if (Screen.currentResolution.ToString() == "1920 x 1080")
        {
            ResolutionMenu.GetComponent<Dropdown>().value = 1;
            GameObject.Find("Resolution").GetComponent<Text>().text = "1080p";
        }

        if (PlayerPrefs.GetString("Resolution") == "720p")
        {
            Screen.SetResolution(1280, 720, fullscreen);
        }
        else if (PlayerPrefs.GetString("Resolution") == "1080p")
        {
            Screen.SetResolution(1920, 1080, fullscreen);
        }

        // Sound
        MusicSlider.GetComponent<Slider>().value = soundManager.GetComponent<AudioSource>().volume * 100;
        SoundEffectsSlider.GetComponent<Slider>().value = sfxManager.GetComponent<AudioSource>().volume * 100;
    }

    public void ResolutionChanged()
    {
        if (ResolutionMenu.GetComponent<Dropdown>().value == 0)
        {
            Screen.SetResolution(1280, 720, fullscreen);
            GameObject.Find("Resolution").GetComponent<Text>().text = "720p";
            PlayerPrefs.SetString("Resolution", "720p");
        }
        else if (ResolutionMenu.GetComponent<Dropdown>().value == 1)
        {
            Screen.SetResolution(1920, 1080, fullscreen);
            GameObject.Find("Resolution").GetComponent<Text>().text = "1080p";
            PlayerPrefs.SetString("Resolution", "1080p");
        }
    }

    public void FullscreenChanged()
    {
        if (FullscreenToggle.GetComponent<Toggle>().isOn)
        {
            fullscreen = true;
            Screen.fullScreen = true;
            PlayerPrefs.SetString("Fullscreen", "True");
        }
        else
        {
            fullscreen = false; 
            Screen.fullScreen = false;
            PlayerPrefs.SetString("Fullscreen", "False");
        }
    }

    public void MusicVolumeChanged()
    {
        if (GameObject.Find("Music Text") != null)
        {
            soundManager.GetComponent<AudioSource>().volume = MusicSlider.GetComponent<Slider>().value / 100;
            GameObject.Find("Music Text").GetComponent<Text>().text = MusicSlider.GetComponent<Slider>().value.ToString();
        }
    }

    public void SoundEffectsVolumeChanged()
    {
        if (GameObject.Find("Sound Effects Text") != null)
        {
            sfxManager.GetComponent<AudioSource>().volume = SoundEffectsSlider.GetComponent<Slider>().value / 100;
            GameObject.Find("Sound Effects Text").GetComponent<Text>().text = SoundEffectsSlider.GetComponent<Slider>().value.ToString();
        }     
    }
}
