using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {
    public Animator cam;

	// Use this for initialization
	void Start () {
        cam = transform.GetComponent<Animator>();
	}
	
    public void Peace_5()
    {
        cam.SetTrigger("PanUp");

    }
}
