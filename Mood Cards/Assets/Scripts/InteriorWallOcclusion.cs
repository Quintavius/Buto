using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorWallOcclusion : MonoBehaviour {
    public float cullDistance = 30;
    float dist;
    MeshRenderer mesh;

	// Use this for initialization
	void Start () {
        if (GetComponent<MeshRenderer>() != null)
        {
            mesh = GetComponent<MeshRenderer>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (dist < cullDistance)
        {
            if (mesh != null)
            {
                mesh.enabled = true;
            }
            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        else
        {
            if (mesh != null)
            {
                mesh.enabled = false;
            }
            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
	}
}
