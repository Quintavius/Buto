using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FadeSkybox : MonoBehaviour {
    Material sky;
    public float t;

	// Use this for initialization
	void Start () {
        sky = GetComponent<Skybox>().material;
	}
	
	// Update is called once per frame
	void Update () {
            sky.SetFloat("_Exposure", t);

	}
}
