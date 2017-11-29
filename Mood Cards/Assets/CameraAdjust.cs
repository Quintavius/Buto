using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAdjust : MonoBehaviour {
    public float Xmin;
    public float Xmax;
    public float Ymin;
    public float Ymax;
    public float smoothing;
    float Ydefault;
    float Xdefault;

    private float xref;
    private float yref;
    ExplorationNav buto;

    CinemachineFollowZoom zoom;
    CinemachineComposer vcam;
    CameraSnapTo camMove;

    	// Use this for initialization
	void Start () {
        vcam = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        Ydefault = vcam.m_ScreenY;
        Xdefault = vcam.m_ScreenX;
        buto = FindObjectOfType<ExplorationNav>();
        zoom = GetComponent<CinemachineFollowZoom>();
        camMove = FindObjectOfType<CameraSnapTo>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!buto.movementLock && !camMove.move)
        {
            //Follow mouse
            var xPos = Input.mousePosition.x / Screen.width;
            var yPos = Input.mousePosition.y / Screen.height;

            var xLerp = Mathf.Lerp(Xmin, Xmax, 1 - xPos);
            var yLerp = Mathf.Lerp(Ymin, Ymax, yPos);

            vcam.m_ScreenX = Mathf.SmoothDamp(vcam.m_ScreenX, xLerp, ref xref, smoothing);
            vcam.m_ScreenY = Mathf.SmoothDamp(vcam.m_ScreenY, yLerp, ref yref, smoothing);


        }

	}

}
