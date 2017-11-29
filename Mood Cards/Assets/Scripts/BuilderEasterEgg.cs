using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderEasterEgg : MonoBehaviour {
    public GameObject hat;
    Material[] rend;
    public Material builderMat;
    SaveData save;
	// Use this for initialization
	void Start () {
        //if (SaveData.current.BuilderButo == true)
        //{
        //    EnableBuilder();
        //}
    }
	
	// Update is called once per frame
	public void EnableBuilder () {
        hat.SetActive(true);

        rend = GameObject.Find("MainCharacter").GetComponent<Renderer>().materials;
        rend[1] = builderMat;
        GameObject.Find("MainCharacter").GetComponent<Renderer>().materials = rend;
        //SaveData.current.BuilderButo = true;
    }
}
