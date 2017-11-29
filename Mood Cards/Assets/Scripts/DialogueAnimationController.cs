using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimationController : MonoBehaviour {
    public Animator ani;

	// Use this for initialization
	void Start () {
        ani = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAnimation(string play)
    {
        ani.SetTrigger(play);
    }
}
