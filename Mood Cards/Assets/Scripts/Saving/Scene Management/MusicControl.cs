using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {
    SoundManager soundManager;

	// Use this for initialization
	void Start () {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public void PlayTheme(string themeName)
    {
        soundManager.PlayTheme(themeName);
    }
}
