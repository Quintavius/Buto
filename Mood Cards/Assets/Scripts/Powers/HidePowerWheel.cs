using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePowerWheel : MonoBehaviour {
    public GameObject Canvas;
    public GameObject Button;
	public void Hide () {
        Canvas.SetActive(false);
        Button.SetActive(false);
		}

    public void Show()
    {
        Canvas.SetActive(true);
        Button.SetActive(true);
    }
}
