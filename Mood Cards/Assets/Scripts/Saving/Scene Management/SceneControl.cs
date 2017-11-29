using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class SceneControl : MonoBehaviour {
    SceneChanger sceneChanger;

    // Use this for initialization
    void Start()
    {
        sceneChanger = GameObject.Find("Scene Manager Master").GetComponent<SceneChanger>();
    }

    public void EnableMinigames()
    {
        SceneManager.LoadScene("MiniGameScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    public void LoadScene(string sceneToLoad)
    {
        //sceneChanger.LastScene = SceneManager.GetActiveScene().name;
        LastSceneHolder.LastSceneStatic = SceneManager.GetActiveScene().name;
        sceneChanger.NextScene(sceneToLoad);
    }

    public void GetLastScene()
    {
        Flowchart flow = FindObjectOfType<Flowchart>();
        var s = LastSceneHolder.LastSceneStatic;
        flow.SetStringVariable("lastScene", s);
    }

    public void SetPlayerPosition(Transform player, Transform camera)
    {
        var buto = FindObjectOfType<ExplorationNav>();
        //var tracker = GameObject.Find("CameraCenter");
        buto.agent.Warp(player.position);

        var cam = GameObject.Find("CameraCenter");
        cam.transform.position = camera.position;
        cam.transform.rotation = camera.rotation;
    }

    public void EnableRageGame(string WinningBlock) {
        FindObjectOfType<MiniGameScript>().EnableRage(WinningBlock);
    }
    
    public void SaveCurrentScene()
    {
        var current = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("lastKnownLocation", current);
        var last = LastSceneHolder.LastSceneStatic;
        PlayerPrefs.SetString("lastScene", last);
    } 

    public void EnableFearGame()
    {
        FindObjectOfType<MiniGameScript>().EnableFear();
    }

    public void DisableGames()
    {
        FindObjectOfType<MiniGameScript>().DisableAll();
    }
}
