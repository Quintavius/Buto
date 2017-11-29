using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDepth : MonoBehaviour {
    public int depth;

	// Use this for initialization
	void OnGUI () {
        GUI.depth = depth;
        Debug.Log(GUI.depth);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
