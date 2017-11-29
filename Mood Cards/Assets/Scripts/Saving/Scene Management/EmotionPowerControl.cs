using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionPowerControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnablePower(string power)
    {
        if (power == "rage") { SaveData.current.RagePower = true; }
        else
if (power == "peace") { SaveData.current.PeacePower = true; }
        else
if (power == "joy") { SaveData.current.JoyPower = true; }
        else
if (power == "despair") { SaveData.current.DespairPower = true; }
        else
if (power == "fear") { SaveData.current.FearPower = true; }
        else
if (power == "wonder") { SaveData.current.WonderPower = true; }

        FindObjectOfType<EmotionWheel>().ReloadSaveData();
    }
}
