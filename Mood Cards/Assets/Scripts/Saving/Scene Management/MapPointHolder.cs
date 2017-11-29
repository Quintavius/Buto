using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapPointHolder {
    //This is just for vertical slice, we'll make a save system to store map position and stuff later on
    private static float x, y, z;
    private static int point;
    public static float X { get { return x; } set { x = value; } }
    public static float Y { get { return y; } set { y = value; } }
    public static float Z { get { return z; } set { z = value; } }
    public static int Point { get { return point; } set { point = value; } }
}
