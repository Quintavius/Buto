﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
