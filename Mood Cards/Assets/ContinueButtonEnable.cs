using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonEnable : MonoBehaviour {
    Button continueButton;
	// Use this for initialization
	void Start () {
        continueButton = GetComponent<Button>();
        if (PlayerPrefs.HasKey("lastKnownLocation"))
        {
            continueButton.interactable = true;
        }else
        {
            continueButton.interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
