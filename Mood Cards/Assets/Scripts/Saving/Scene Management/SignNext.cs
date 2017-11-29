using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SignNext : MonoBehaviour {
    [Header("Setup")]
    public float triggerDistance;
    public Transform player;
    public string targetScene;
    public AnimationCurve scaleCurve;
    public float vanishDuration;

    //Hiddens
    float dist;
    Flowchart flowchart;
    SceneChanger sceneChanger;
    float t;
    public bool vanish;
    public bool appear;
    public float startScale;

    // Use this for initialization
    void Start () {
        startScale = transform.localScale.y;
        flowchart = FindObjectOfType<Flowchart>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        transform.localScale = new Vector3(0, 0, 0);
        t = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (vanish)
        {
            t += Time.deltaTime/vanishDuration;
            var scale = scaleCurve.Evaluate(t) * startScale;
            transform.localScale = new Vector3 (scale,scale,scale);
        }

        if (appear)
        {
            if (t > 0)
            {
                t -= Time.deltaTime / vanishDuration;
                var scale = scaleCurve.Evaluate(t) * startScale;
                transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                appear = false;
            }
        }
    }

    public void MoveToScene()
    {
        vanish = true;
        StartCoroutine(sceneChanger.LoadScene(targetScene));
    }

    public void Appear()
    {
        appear = true;
    }
}
