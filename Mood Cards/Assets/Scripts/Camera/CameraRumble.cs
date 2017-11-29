using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRumble : MonoBehaviour {
    public float ShakeDist = 1;
    private Vector3 originalPosition;
    public float ShakeSpeed = 1;
    public float t;
    // Use this for initialization
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 0)
        {
            var pos = originalPosition;
            pos.y += ShakeDist / 2 - (ShakeDist * Mathf.PerlinNoise(Time.time * ShakeSpeed, 0));
            pos.z += ShakeDist / 2 - (ShakeDist * Mathf.PerlinNoise(0, Time.time * ShakeSpeed));
            transform.localPosition = pos;
            t--;
        }
    }
    public void CameraShake(float duration, float distance, float speed)
    {
        ShakeSpeed = speed;
        ShakeDist = distance;
        t = duration / Time.deltaTime;
    }
}