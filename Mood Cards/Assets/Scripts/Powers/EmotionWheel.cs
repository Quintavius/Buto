using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionWheel : MonoBehaviour {

    // Wheel canvas
    public GameObject wheelCanvas;

    // Each sprite
    public GameObject FearBackLock;
    public GameObject DespairBackLock;
    public GameObject JoyBackLock;
    public GameObject PeaceBackLock;
    public GameObject RageBackLock;
    public GameObject WonderBackLock;

    public GameObject FearIconLock;
    public GameObject DespairIconLock;
    public GameObject JoyIconLock;
    public GameObject PeaceIconLock;
    public GameObject RageIconLock;
    public GameObject WonderIconLock;

    public Animator PeaceIconAni;
    public Animator DespairIconAni;
    public Animator JoyIconAni;
    public Animator WonderIconAni;
    public Animator FearIconAni;
    public Animator RageIconAni;

    public string hoverEmotion = "None";

    ExplorationNav buto;

    // Booleans for whether an emotion has been unlocked
    [HideInInspector]
    public bool FearPower,
                JoyPower,
                DespairPower,
                PeacePower,
                RagePower,
                WonderPower;

    // String to store which emotion is currently selected
    public string CurrentlySelectedPower;

    // Use this for initialization
    void Start () {
        buto = FindObjectOfType<ExplorationNav>();

        // Values for testing
        FearPower = SaveData.current.FearPower;
        JoyPower = SaveData.current.JoyPower;
        DespairPower = SaveData.current.DespairPower;
        PeacePower = SaveData.current.PeacePower;
        RagePower = SaveData.current.RagePower;
        WonderPower = SaveData.current.WonderPower;
        UpdatePowerSelection();

        CurrentlySelectedPower = "None";
    }
	
	// Update is called once per frame
	void Update () {
        //UpdatePowerSelection();
        //ShortcutKey();

        // ------------------------------------------------------------------------------
        // We can update the cursor here depending on which emotion is currently selected
        // ------------------------------------------------------------------------------

    }

    public void ReloadSaveData()
    {
        FearPower = SaveData.current.FearPower;
        JoyPower = SaveData.current.JoyPower;
        DespairPower = SaveData.current.DespairPower;
        PeacePower = SaveData.current.PeacePower;
        RagePower = SaveData.current.RagePower;
        WonderPower = SaveData.current.WonderPower;
        UpdatePowerSelection();
    }

    private void UpdatePowerSelection()
    {
        // True
        if (FearPower)
        {
            FearBackLock.SetActive(false);
            FearIconLock.SetActive(false);
        }

        if (JoyPower)
        {
            JoyBackLock.SetActive(false);
            JoyIconLock.SetActive(false);
        }

        if (DespairPower)
        {
            DespairBackLock.SetActive(false);
            DespairIconLock.SetActive(false);
        }

        if (PeacePower)
        {
            PeaceBackLock.SetActive(false);
            PeaceIconLock.SetActive(false);
        }

        if (RagePower)
        {
            RageBackLock.SetActive(false);
            RageIconLock.SetActive(false);
        }

        if (WonderPower)
        {
            WonderBackLock.SetActive(false);
            WonderIconLock.SetActive(false);
        }

        // False
        if (!FearPower)
        {
            FearBackLock.SetActive(true);
            FearIconLock.SetActive(true);
        }

        if (!JoyPower)
        {
            JoyBackLock.SetActive(true);
            JoyIconLock.SetActive(true);
        }

        if (!DespairPower)
        {
            DespairBackLock.SetActive(true);
            DespairIconLock.SetActive(true);
        }

        if (!PeacePower)
        {
            PeaceBackLock.SetActive(true);
            PeaceIconLock.SetActive(true);
        }

        if (!RagePower)
        {
            RageBackLock.SetActive(true);
            RageIconLock.SetActive(true);
        }

        if (!WonderPower)
        {
            WonderBackLock.SetActive(true);
            WonderIconLock.SetActive(true);
        }
    }
    public void SetHoverEmotion(string emotion)
    {
        hoverEmotion = emotion;
    }
    // For hover over
    public void OnHover(string Emotion)
    {
        if (Emotion == "Fear")
        {
            FearIconAni.SetTrigger("Highlighted");
        }
        else if (Emotion == "Despair")
        {
            DespairIconAni.SetTrigger("Highlighted");
        }
        else if (Emotion == "Joy")
        {
            JoyIconAni.SetTrigger("Highlighted");
        }
        else if (Emotion == "Peace")
        {
            PeaceIconAni.SetTrigger("Highlighted");
        }
        else if (Emotion == "Rage")
        {
            RageIconAni.SetTrigger("Highlighted");
        }
        else if (Emotion == "Wonder")
        {
            WonderIconAni.SetTrigger("Highlighted");
        }
    }

    public void OnExit (string Emotion)
    {
        if (Emotion == "Fear")
        {
            FearIconAni.SetTrigger("Normal");
        }
        else if (Emotion == "Despair")
        {
            DespairIconAni.SetTrigger("Normal");
        }
        else if (Emotion == "Joy")
        {
            JoyIconAni.SetTrigger("Normal");
        }
        else if (Emotion == "Peace")
        {
            PeaceIconAni.SetTrigger("Normal");
        }
        else if (Emotion == "Rage")
        {
            RageIconAni.SetTrigger("Normal");
        }
        else if (Emotion == "Wonder")
        {
            WonderIconAni.SetTrigger("Normal");
        }
    }

    // For on click animations
    public void OnClick(string emotionName)
    {
        CurrentlySelectedPower = emotionName;
        Debug.Log(emotionName);
        //wheelCanvas.GetComponentInChildren<Animator>().SetBool("active", false);
        WheelButton();
    }

    public void ShortcutKey()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (wheelCanvas.GetComponentInChildren<Animator>().GetBool("active"))
            {
                wheelCanvas.GetComponentInChildren<Animator>().SetBool("active", false);
                buto.SetMoveLock(false);
            }
            else
            {
                wheelCanvas.GetComponentInChildren<Animator>().SetBool("active", true);
                buto.SetMoveLock(true);
            }
        }
    }

    public void WheelButton()
    {
        if (wheelCanvas.GetComponentInChildren<Animator>().GetBool("active"))
        {
            wheelCanvas.GetComponentInChildren<Animator>().SetBool("active", false);
            buto.SetMoveLock(false);
        }
        else
        {
            wheelCanvas.GetComponentInChildren<Animator>().SetBool("active", true);
            buto.SetMoveLock(true);
        }
    }

    public void ClearPower()
    {
        CurrentlySelectedPower = "None";
    }



}
