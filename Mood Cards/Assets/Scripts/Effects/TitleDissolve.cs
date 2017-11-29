using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDissolve : MonoBehaviour {
    public float rate;
    public bool trigger = false;

    Renderer rend;
    Material mat;

	// Use this for initialization
	void Start () {
        rend = transform.GetComponent<Renderer>();
        mat = rend.material;
        mat.SetFloat("_Cutoff", 1);


    }
	
	// Update is called once per frame
	void Update () {
        if (trigger)
        {
            var currentCutoff = mat.GetFloat("_Cutoff");

            if (currentCutoff >= 0.085)
            {
                currentCutoff -= rate*Time.deltaTime;
                mat.SetFloat("_Cutoff", currentCutoff);
            }
        }

    }

    public void TriggerFade()
    {
        trigger = true;
    }
}
