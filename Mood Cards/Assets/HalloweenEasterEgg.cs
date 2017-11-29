using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HalloweenEasterEgg : MonoBehaviour {
    System.DateTime date;
    Flowchart flow;
    System.DateTime halloween;

	void Start () {
        date = System.DateTime.Today;

        var year = System.DateTime.Today.Year;
        halloween = new System.DateTime(year, 10, 31);

        flow = FindObjectOfType<Flowchart>();
	}
	
	public void CheckDate () {
		if (date == halloween)
        {
            flow.SetBooleanVariable("Halloween", true);
        }
	}
}
