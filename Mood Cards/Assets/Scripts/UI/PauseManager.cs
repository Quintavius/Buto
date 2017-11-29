using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public static PauseManager instance = null;

    GameObject[] pauseItems;
    ExplorationNav buto;

    private void Awake()
    {
        ////Check if there is already an instance of SoundManager
        //if (instance == null)
        //    //if not, set it to this.
        //    instance = this;
        ////If instance already exists:
        //else if (instance != this)
        //    //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
        //    Destroy(gameObject);

        ////Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // grab all objects with the pause tag
        pauseItems = GameObject.FindGameObjectsWithTag("ShowOnPause");

        //Grab buto
        buto = GameObject.Find("Buto_Exploration").GetComponent<ExplorationNav>();

        // don't bother deactivating pause objects, it does it for you automatically here
        HidePaused(); 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 1 && !buto.movementLock)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0)
            {
                UnpauseGame();
            }
        }
    }

    // call to pause the game
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            buto.SetMoveLock(true);
            Time.timeScale = 0;
            ShowOnPause();
        }
    }

    // call to unpause the game
    public void UnpauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
            buto.SetMoveLock(false);
        }
    }

    // Shows pause items during pause
    public void ShowOnPause()
    {
        foreach (GameObject item in pauseItems)
        {
            item.SetActive(true);
        }
    }

    // Hides pause items when unpaused
    public void HidePaused()
    {
        foreach (GameObject item in pauseItems)
        {
            item.SetActive(false);
        }
    }


    // Call this to call the scene changing function in SceneChanger
    public void ChangeScene(string sceneName)
    {
        HidePaused();

        SceneChanger sceneChanger = FindObjectOfType<SceneChanger>();

        sceneChanger.NextScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
