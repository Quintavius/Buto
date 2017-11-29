using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Autosave : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if (SceneManager.GetActiveScene().buildIndex > 0) //Compensate for Main Menu, increase in case of extra scenes before game.
        //{
        //    SaveData.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        //}

        //SaveData.Save();
	}
}
