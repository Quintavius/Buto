using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnyKey : MonoBehaviour {
    //public SceneChanger sceneChanger;
    public GameObject menuCanvas;

	// Use this for initialization
	void Awake () {
        //sceneChanger = GameObject.Find("Scene Manager").GetComponent<SceneChanger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
        {
            menuCanvas.SetActive(true);
            transform.gameObject.SetActive(false);
            //sceneChanger.SceneLoad("Prologue");
        }
	}
}
