using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public Transform track;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = track.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = track.position - offset;
	}
}
