using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button[] menuOptions;

	// Use this for initialization
	void Start () {
        // Just for testing save data
        //SaveData.current = new SaveData();
        //SaveData.current.peacePower = true;
        //SaveLoad.Save();
	}
	
	// Update is called once per frame
	void Update () {
        float axis = Input.GetAxis("Vertical");
        if (axis < 0)
        {
            menuOptions[1].Select();
        }
        else if (axis > 0)
        {
            menuOptions[0].Select();
        }
        
        // Just for testing save data
        if (Input.GetKeyDown("l"))
        {
            foreach (SaveData saveData in SaveLoad.saveDataFiles)
            {
                Debug.Log("Peace: " + saveData.peacePower);
            }
        }
	}
}
