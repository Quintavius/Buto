using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelectionScript : MonoBehaviour {

    public GameObject[] SceneButtons;

    private string sceneState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            PlayerPrefs.SetString("SceneState", "Scene1");
        }
        if (Input.GetKeyDown("2"))
        {
            PlayerPrefs.SetString("SceneState", "Scene2");
        }
        if (Input.GetKeyDown("3"))
        {
            PlayerPrefs.SetString("SceneState", "Scene3");
        }
        if (Input.GetKeyDown("4"))
        {
            PlayerPrefs.SetString("SceneState", "Scene4");
        }
        if (Input.GetKeyDown("5"))
        {
            PlayerPrefs.SetString("SceneState", "Scene5");
        }
        if (Input.GetKeyDown("6"))
        {
            PlayerPrefs.SetString("SceneState", "Scene6");
        }

        CheckSave();
    }

    void CheckSave()
    {
        sceneState = PlayerPrefs.GetString("SceneState");

        for (int i = 0; i < SceneButtons.Length; i++)
        {
            if (sceneState == SceneButtons[i].name)
            {
                SceneButtons[i].SetActive(true);
                for (int j = i; j >= 0; j--)
                {
                    SceneButtons[j].SetActive(true);
                }
            }
            else
            {
                SceneButtons[i].SetActive(false);
            }   
        }
    }

    void SaveSceneState(string sceneName)
    {
        PlayerPrefs.SetString("SceneState", sceneName);
    }

    void SaveCurrentScene(string sceneName)
    {
        PlayerPrefs.SetString("CurrentScene", sceneName);
    }
}
