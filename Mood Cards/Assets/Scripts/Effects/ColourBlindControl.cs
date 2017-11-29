using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ColourBlindControl : MonoBehaviour {
    PostProcessingBehaviour FX;
    public PostProcessingProfile colourBlindProfile;
    PostProcessingProfile startFX;
     

	// Use this for initialization
	void Start () {
        FX = transform.GetComponent<PostProcessingBehaviour>();
        startFX = transform.GetComponent<PostProcessingBehaviour>().profile;
    }
	
	// Update is called once per frame
	void Update () {
        
		if (ColourBlindMode.ColourBlindActive)
        {
            FX.profile = colourBlindProfile;
        }
        else
        {
            FX.profile = startFX;
        }


        //Quick toggle
        if (Input.GetKeyDown(KeyCode.F4))
        {
            ColourBlindMode.ColourBlindActive = !ColourBlindMode.ColourBlindActive;
        }
	}
}
