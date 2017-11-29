using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Autofocus : MonoBehaviour {
    PostProcessingProfile profileHolder;
    PostProcessingBehaviour cam;
    Transform player;
    float dist;

	// Use this for initialization
	void Start () {
        cam = Camera.main.GetComponent<PostProcessingBehaviour>(); ;
        player = GameObject.Find("Buto_Exploration").transform;
        profileHolder = cam.profile;
	}
	
	// Update is called once per frame
	void Update () {
        var dof = profileHolder.depthOfField.settings;
        dist = Vector3.Distance(Camera.main.transform.position, player.position);

        dof.focusDistance = dist;
        profileHolder.depthOfField.settings = dof;
	}
}
