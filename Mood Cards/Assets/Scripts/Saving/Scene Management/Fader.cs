using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Fader : MonoBehaviour
{
    public GameObject loadingAnimation;

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -10; // the texture's order in the draw hierarchy, lower number means rendering on top
    private float alpha = 1.0f;
    private int fadeDir = -1; // direction to fade: in = -1, out = 1

    public static Fader instance = null;

    void Awake()
    {
        BeginFade(-1);
    }

    void OnGUI()
    {
       
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        //if (alpha == 1)
        //{
        //    loadingAnimation.SetActive(true);
        //}else
        //{
        //    loadingAnimation.SetActive(false);
        //}

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }

    //private void OnLevelWasLoaded()
    //{
    //    BeginFade(-1);
    //}

    public void FadeIn()
    {
        BeginFade(-1);
    }

    private void Update()
    {
        //if (alpha == 1)
        //{
        //    loadingAnimation.SetActive(true);
        //}
        //else
        //{
        //    loadingAnimation.SetActive(false);
        //}
    }

}