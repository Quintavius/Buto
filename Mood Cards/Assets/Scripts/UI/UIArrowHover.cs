using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowHover : MonoBehaviour {
    public AnimationCurve anim;
    public float speed;
    public float range;
    public float offset;
    public float enableX;
    public float enableY;
    RectTransform rect;

    Vector3 start;
	// Use this for initialization
	void Awake () {
        rect = GetComponent<RectTransform>();
        start = rect.localPosition;
        anim.postWrapMode = WrapMode.PingPong;
        anim.preWrapMode = WrapMode.PingPong;
	}
	
	// Update is called once per frame
	void Update () {
        var move = anim.Evaluate((Time.time * speed) + offset) * range;
        rect.localPosition += new Vector3 (move*enableX,move*enableY,0);
	}

    private void OnEnable()
    {
        rect.localPosition = start;
    }
}
