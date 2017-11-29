using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHover : MonoBehaviour
            , IPointerEnterHandler
            , IPointerExitHandler
{

    public bool isHovering;
    private EmotionWheel emotionWheel;

    // Use this for initialization
    void Start () {
        emotionWheel = FindObjectOfType<EmotionWheel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isHovering)
        {

        }
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        emotionWheel.OnHover(emotionWheel.hoverEmotion);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        emotionWheel.OnExit(emotionWheel.hoverEmotion);
    }
}
