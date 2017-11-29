using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFeedbackForm : MonoBehaviour {
    public CanvasGroup can;

    bool fading;

    private void Update()
    {
        if (fading)
        {
            can.alpha += Time.deltaTime/2;
        }
    }

    public void FadeInCanvas()
    {
        fading = true;
    }

	public void GoToFeedback()
    {
        if (fading)
        {
            Application.OpenURL("https://goo.gl/forms/Fb9WVszYCDJAhWIS2");
        }
    }
}
