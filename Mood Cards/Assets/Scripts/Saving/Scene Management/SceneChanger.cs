using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance = null;
    public string LastScene;

    private bool loadScene = false;
    private Text LoadingText;
    public GameObject LoadingCanvas;
    private GameObject[] HideOnLoad;

    public Image FadeImage;

    public float alpha;



    private void Awake()
    {
        // Looking for the black screen in the loading canvas
        FadeImage = GameObject.Find("FadeScreen").GetComponent<Image>();
    }

    private void Start()
    {
        LoadingCanvas = GameObject.Find("Loading Canvas");
        LoadingCanvas.SetActive(false);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                NewButton();
            }
        }

        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);

        if (loadScene)
        {
            alpha += 1.5f * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);       
        }

        else
        {
            alpha -= 1.5f * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);            
        }
    }

    IEnumerator Fading()
    {
        float fadeTime = GameObject.Find("Scene Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }

    public IEnumerator LoadSceneIndex(int sceneIndex)
    {
        float fadeTime = GameObject.Find("Scene Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator LoadScene(string sceneName)
    {
        float fadeTime = GameObject.Find("Scene Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
       
        SceneManager.LoadScene(sceneName);
    }

    public void SceneLoad(string SceneName)
    {
        StartCoroutine(LoadScene(SceneName));
    }

    public void SceneLoadIndex(int SceneBuildIndex)
    {
        StartCoroutine(LoadSceneIndex(SceneBuildIndex));
    }

    public void restartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NewButton()
    {
        // Next scene after main menu
        StartCoroutine(LoadScene("Prologue"));
    }

    public void ContinueButton()
    {
        var sceneToLoad = PlayerPrefs.GetString("lastKnownLocation");
        LastScene = PlayerPrefs.GetString("lastScene");
        LastSceneHolder.LastSceneStatic = LastScene;
        NextScene(sceneToLoad);
    }

    public void ExitButton()
    {
        Application.Quit();
    }


    // Use this to load new scenes now
    public void NextScene(string SceneName)
    {
        if (LoadingCanvas == null)
        {
            LoadingCanvas = GameObject.Find("Loading Canvas");
        }

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        HideOnLoad = GameObject.FindGameObjectsWithTag("HideOnLoad");

        LoadingCanvas.SetActive(true); // activates the loading canvas
        LoadingText = LoadingCanvas.transform.Find("LoadingText").GetComponent<Text>();

        foreach (GameObject item in HideOnLoad)
        {
            item.SetActive(false);
        }

        loadScene = true;
        LoadingText.text = "Loading...";

        StartCoroutine(LoadNewScene(SceneName));

        if (loadScene)
        {
            LoadingText.color = new Color(LoadingText.color.r, LoadingText.color.g, LoadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            yield return null;
        }

        loadScene = false;
        
    }

    // Pause to main menu
    public void PauseToMM(string sceneName)
    {
        PauseManager pauseManager = FindObjectOfType<PauseManager>();
        pauseManager.ChangeScene(sceneName);
    }

}
