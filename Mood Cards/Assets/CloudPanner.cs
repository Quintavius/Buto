using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPanner : MonoBehaviour {
    public float PanSpeedX;
    public float PanSpeedY;
    Renderer mat;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mat.material.mainTextureOffset += new Vector2(PanSpeedX * Time.deltaTime, PanSpeedY * Time.deltaTime);
	}
}
