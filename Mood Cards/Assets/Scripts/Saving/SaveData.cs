using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    //One script to hold them all
    //One script to find them
    //One script to bring them all
    //and in the save file bind them


    //Variables
    public static SaveData current;

    public int sceneProgress, 
                currentScene;

    public bool peacePower, 
                joyPower, 
                wonderPower, 
                despairPower, 
                fearPower, 
                ragePower; //Are powers unlocked

    public bool peaceSecret, 
                joySecret, 
                wonderSecret, 
                despairSecret, 
                fearSecret, 
                rageSecret; //Are secrets found

    public bool builderButo;

    ////Variable Functions
    public int SceneProgress { get { return sceneProgress; } set { sceneProgress = value; } }
    public int CurrentScene { get { return currentScene; } set { currentScene = value; } }

    public bool PeacePower { get { return peacePower; } set { peacePower = value; } }
    public bool JoyPower { get { return joyPower; } set { joyPower = value; } }
    public bool WonderPower { get { return wonderPower; } set { wonderPower = value; } }
    public bool DespairPower { get { return despairPower; } set { despairPower = value; } }
    public bool FearPower { get { return fearPower; } set { fearPower = value; } }
    public bool RagePower { get { return ragePower; } set { ragePower = value; } }

    public bool PeaceSecret { get { return peaceSecret; } set { peaceSecret = value; } }
    public bool JoySecret { get { return joySecret; } set { joySecret = value; } }
    public bool WonderSecret { get { return wonderSecret; } set { wonderSecret = value; } }
    public bool DespairSecret { get { return despairSecret; } set { despairSecret = value; } }
    public bool FearSecret { get { return fearSecret; } set { fearSecret = value; } }
    public bool RageSecret { get { return rageSecret; } set { rageSecret = value; } }

    public bool BuilderButo { get { return builderButo; } set { builderButo = value; } }

    //Save and Load Functions
    public void Save()
    {
        //Gonna use PlayerPrefs for now but this would be better to serialize so players can't just set their progress in the preference file
        //Saving everything here to keep it all in one place for maintenance

        //Check on progress
        if (currentScene > sceneProgress)
        {
            sceneProgress = currentScene;
        }

        //PlayerPrefs.SetInt("sceneProgress", sceneProgress);
        //PlayerPrefs.SetInt("currentScene", currentScene);

        //PlayerPrefExtension.SetBool("peacePower", peacePower);
        //PlayerPrefExtension.SetBool("joyPower", joyPower);
        //PlayerPrefExtension.SetBool("wonderPower", wonderPower);
        //PlayerPrefExtension.SetBool("despairPower", despairPower);
        //PlayerPrefExtension.SetBool("fearPower", fearPower);
        //PlayerPrefExtension.SetBool("ragePower", ragePower);

        //PlayerPrefExtension.SetBool("peaceSecret", peaceSecret);
        //PlayerPrefExtension.SetBool("joySecret", joySecret);
        //PlayerPrefExtension.SetBool("wonderSecret", wonderSecret);
        //PlayerPrefExtension.SetBool("despairSecret", despairSecret);
        //PlayerPrefExtension.SetBool("fearSecret", fearSecret);
        //PlayerPrefExtension.SetBool("rageSecret", rageSecret);

    }

    public void Load()
    {
        //sceneProgress = PlayerPrefs.GetInt("sceneProgress");
        //currentScene = PlayerPrefs.GetInt("currentScene");

        //peacePower = PlayerPrefExtension.GetBool("peacePower");
        //joyPower = PlayerPrefExtension.GetBool("joyPower");
        //wonderPower = PlayerPrefExtension.GetBool("wonderPower");
        //despairPower = PlayerPrefExtension.GetBool("despairPower");
        //fearPower = PlayerPrefExtension.GetBool("fearPower");
        //ragePower = PlayerPrefExtension.GetBool("ragePower");

        //peaceSecret = PlayerPrefExtension.GetBool("peaceSecret");
        //joySecret = PlayerPrefExtension.GetBool("joySecret");
        //wonderSecret = PlayerPrefExtension.GetBool("wonderSecret");
        //despairSecret = PlayerPrefExtension.GetBool("despairSecret");
        //fearSecret = PlayerPrefExtension.GetBool("fearSecret");
        //rageSecret = PlayerPrefExtension.GetBool("rageSecret");
    }

    public SaveData()
    {

    }
}
