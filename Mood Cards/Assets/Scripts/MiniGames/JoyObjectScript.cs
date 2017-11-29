using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyObjectScript : MonoBehaviour {

    MiniGameScript miniGameScript;

	// Use this for initialization
	void Start () {
        miniGameScript = FindObjectOfType<MiniGameScript>();		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            miniGameScript.JoyColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            miniGameScript.JoyColliding = false;
        }
    }
}
