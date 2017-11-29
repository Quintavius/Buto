using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderTrigger : MonoBehaviour {

    public bool onCenter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onCenter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onCenter = false;
    }
}
