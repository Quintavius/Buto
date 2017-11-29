using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyZoom : MonoBehaviour {
    public Camera skyCam;
    public Camera mainCam;
	// Use this for initialization
	void Start () {
        skyCam = GetComponent<Camera>();
        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        skyCam.fieldOfView = mainCam.fieldOfView;
	}
}
