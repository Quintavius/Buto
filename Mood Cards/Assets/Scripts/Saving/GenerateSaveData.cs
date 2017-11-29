using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSaveData : MonoBehaviour {
    public bool PeacePower;
    public bool JoyPower;
    public bool WonderPower;
    public bool DespairPower;
    public bool FearPower;
    public bool RagePower;

    // Use this for initialization
    void Start () {
        SaveData.current = new SaveData();
        SaveData.current.PeacePower = PeacePower;
        SaveData.current.JoyPower = JoyPower;
        SaveData.current.WonderPower = WonderPower;
        SaveData.current.DespairPower = DespairPower;
        SaveData.current.FearPower = FearPower;
        SaveData.current.RagePower = RagePower;

        SaveLoad.Save();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
