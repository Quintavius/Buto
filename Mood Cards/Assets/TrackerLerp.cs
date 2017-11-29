using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerLerp : MonoBehaviour {
    private Vector3 vel;
    ExplorationNav nav;
    bool sceneStarted;

    private void Start()
    {
        nav = FindObjectOfType<ExplorationNav>();
    }
    
	void Update () {
        if (!sceneStarted)
        {
            if (transform.localPosition != Vector3.zero)
            {
                nav.movementLock = true;
                transform.localPosition = Vector3.SmoothDamp(transform.localPosition, Vector3.zero, ref vel, 1.5f);
            }

            if (Mathf.Abs(transform.localPosition.x) < 0.1f && Mathf.Abs(transform.localPosition.y) < 0.1f && Mathf.Abs(transform.localPosition.z) < 0.1f)
            {
                transform.localPosition = Vector3.zero;
                nav.movementLock = false;
                sceneStarted = true;
            }
        }
	}
}
