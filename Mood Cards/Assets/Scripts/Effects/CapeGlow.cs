using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapeGlow : MonoBehaviour {
    public bool glowing = false;
    Light lamp;

	// Use this for initialization
	void Start () {
        lamp = transform.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (glowing && lamp.intensity <= 5)
        {
            lamp.intensity += Time.deltaTime;
        }
	}

    public void TriggerGlow()
    {
        glowing = true;
    }
}
