using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("k"))
        {
            transform.RotateAround(target.position, Vector3.up, 0.5f);
        }
        if (Input.GetKey("l"))
        {
            transform.RotateAround(target.position, Vector3.down, 0.5f);
        }

       
    }
}
