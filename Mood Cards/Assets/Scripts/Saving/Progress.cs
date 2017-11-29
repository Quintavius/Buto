using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Progress {
    //Variables
    private static int sceneProgress, currentScene;
    private static bool peacePower, joyPower, wonderPower, despairPower, fearPower, ragePower; //Are powers unlocked
    private static bool peaceSecret, joySecret, wonderSecret, despairSecret, fearSecret, rageSecret; //Are secrets found

    //Variable Functions
    public static int SceneProgress { get { return sceneProgress; } set { sceneProgress = value; } }
    public static int CurrentScene { get { return currentScene; } set { currentScene = value; } }

    public static bool PeacePower { get { return peacePower; } set { peacePower = value; } }
    public static bool JoyPower { get { return joyPower; } set { joyPower = value; } }
    public static bool WonderPower { get { return wonderPower; } set { wonderPower = value; } }
    public static bool DespairPower { get { return despairPower; } set { despairPower = value; } }
    public static bool FearPower { get { return fearPower; } set { fearPower = value; } }
    public static bool RagePower { get { return ragePower; } set { ragePower = value; } }

    public static bool PeaceSecret { get { return peaceSecret; } set { peaceSecret = value; } }
    public static bool JoySecret { get { return joySecret; } set { joySecret = value; } }
    public static bool WonderSecret { get { return wonderSecret; } set { wonderSecret = value; } }
    public static bool DespairSecret { get { return despairSecret; } set { despairSecret = value; } }
    public static bool FearSecret { get { return fearSecret; } set { fearSecret = value; } }
    public static bool RageSecret { get { return rageSecret; } set { rageSecret = value; } }
}
