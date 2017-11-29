using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassQuality : MonoBehaviour {
    Terrain terrain;
    int quality;

    int frameCounter = 0;
    float timeCounter = 0.0f;
    float lastFramerate = 0.0f;
    public float refreshTime = 1;

    float qualityModifier = 1;

    private float vel;
	// Use this for initialization
	void Start () {
        terrain = transform.GetComponent<Terrain>();

        SetQuality();

        
	}
	
	// Update is called once per frame
	void Update () {
        //debug
        //SetQuality();

        AdaptiveQuality();
	}

    void SetQuality()
    {
        quality = QualitySettings.GetQualityLevel();
        switch (quality)
        {
            case 0: terrain.detailObjectDistance = 0; terrain.detailObjectDensity = 0; break;
            case 1: terrain.detailObjectDistance = 30; terrain.detailObjectDensity = 0.2f; break;
            case 2: terrain.detailObjectDistance = 80; terrain.detailObjectDensity = 0.4f; break;
            case 3: terrain.detailObjectDistance = 130; terrain.detailObjectDensity = 0.6f; break;
            case 4: terrain.detailObjectDistance = 190; terrain.detailObjectDensity = 0.8f; break;
            case 5: terrain.detailObjectDistance = 250; terrain.detailObjectDensity = 1f; break;
            default: terrain.detailObjectDistance = 250; terrain.detailObjectDensity = 1f; break;
        }
    }
    void AdaptiveQuality()
    {
        if (timeCounter < refreshTime)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;
        }
        else
        {
            lastFramerate = (float)frameCounter / timeCounter;
            qualityModifier = Mathf.Clamp01(lastFramerate / 30); //divided by target fps
            frameCounter = 0;
            timeCounter = 0.0f;
        }


        if (lastFramerate < 20)
        {
            terrain.detailObjectDistance = 250 * qualityModifier;
            terrain.detailObjectDensity = 1 * qualityModifier;
        }
    }
}
