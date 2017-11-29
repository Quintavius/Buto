using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceButtonScript : MonoBehaviour {

    MiniGameScript miniGameScript;

	// Use this for initialization
	void Start () {
        miniGameScript = FindObjectOfType<MiniGameScript>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PeaceButton()
    {
        if (gameObject == miniGameScript.PeaceButtons[0])
        {
            miniGameScript.PeaceButtons.RemoveAt(0);
            Destroy(gameObject);

            if (miniGameScript.PeaceButtons.Count != 0)
            {
                miniGameScript.PeaceButtons[0].transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
            }
        }
    }
}
