using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMap : MonoBehaviour {
    SceneChanger sceneChanger;

    // Use this for initialization
    void Start () {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnterMapScene()
    {
        StartCoroutine(sceneChanger.LoadScene("AnneMap"));
    }

    public void EnterMainMenu()
    {
        StartCoroutine(sceneChanger.LoadScene("AnneMainMenu"));
    }
}
