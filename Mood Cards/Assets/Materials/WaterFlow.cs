using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour {
    public Renderer rend;
    public float flowSpeed = 1;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * flowSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
