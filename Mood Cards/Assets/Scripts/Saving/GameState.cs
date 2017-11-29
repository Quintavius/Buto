using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    SceneChanger SceneChanger;

    bool continued;

    public static GameState instance = null;

    private void Awake()
    {
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

    // Use this for initialization
    void Start () {
        SceneChanger = FindObjectOfType<SceneChanger>();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    SaveGame();
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    SceneChanger.SceneLoad("Main Menu");
        //    Debug.Log(Cursor.lockState);
        //    Debug.Log(Cursor.visible);
        //}
        /*
        if (continued == true)
        {
            // Get player location from last save
            float locx = PlayerPrefs.GetFloat("PlayerLocX");
            float locy = PlayerPrefs.GetFloat("PlayerLocY");
            float locz = PlayerPrefs.GetFloat("PlayerLocZ");
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(locx, locy, locz);

            float rotx = PlayerPrefs.GetFloat("PlayerRotX");
            float roty = PlayerPrefs.GetFloat("PlayerRotY");
            float rotz = PlayerPrefs.GetFloat("PlayerRotZ");
            float rotw = PlayerPrefs.GetFloat("PlayerRotW");
            GameObject.FindGameObjectWithTag("Player").transform.rotation = new Quaternion(rotx, roty, rotz, rotw);

            continued = false;
        }
        */
	}

    public void SaveGame()
    {
        /*
        // Saving the players location in the world
        Vector3 PlayerLoc = FindObjectOfType<Player>().transform.position;
        Quaternion PlayerRot = FindObjectOfType<Player>().transform.rotation;
        // Location
        PlayerPrefs.SetFloat("PlayerLocX", PlayerLoc.x);
        PlayerPrefs.SetFloat("PlayerLocY", PlayerLoc.y);
        PlayerPrefs.SetFloat("PlayerLocZ", PlayerLoc.z);
        // Rotation
        PlayerPrefs.SetFloat("PlayerRotX", PlayerRot.x);
        PlayerPrefs.SetFloat("PlayerRotY", PlayerRot.y);
        PlayerPrefs.SetFloat("PlayerRotZ", PlayerRot.z);
        PlayerPrefs.SetFloat("PlayerRotW", PlayerRot.w);

        // Save current scene
        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);

        Debug.Log("Saved!");
        Debug.Log("Saved scene " + SceneManager.GetActiveScene().name);

        float locx = PlayerPrefs.GetFloat("PlayerLocX");
        float locy = PlayerPrefs.GetFloat("PlayerLocY");
        float locz = PlayerPrefs.GetFloat("PlayerLocZ");

        Debug.Log(locx + "  " +  locy + "  " + locz);
        */
    }

    public void ContinueGame()
    {
        //SceneChanger.ContinueButton();

        // Load the saved scene
        
        //SceneChanger.SceneLoadIndex(SaveData.CurrentScene);

        Debug.Log(PlayerPrefs.GetString("Scene"));


        continued = true;
    }
}
