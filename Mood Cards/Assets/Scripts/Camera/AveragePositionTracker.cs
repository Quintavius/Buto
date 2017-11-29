using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragePositionTracker : MonoBehaviour {
    public List<Transform> TrackPoints;
    Vector3 sum;
	
	// Update is called once per frame
	void Update () {
        sum = Vector3.zero;
        var listSize = TrackPoints.Count;
        foreach (Transform point in TrackPoints)
        {
            sum += point.position;
        }

        transform.position = sum / TrackPoints.Count;
	}
}
