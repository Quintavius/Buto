using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StateControl : MonoBehaviour {
    public Animator state;
    public Flowchart flow;

	// Use this for initialization
	void Start () {
        state = GameObject.Find("StateMachine").GetComponent<Animator>();
        flow = FindObjectOfType<Flowchart>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetStateBool (string parameter) { var value = state.GetBool(parameter); flow.SetBooleanVariable(parameter, value); }
    public void GetStateInt(string parameter) { var value = state.GetInteger(parameter); flow.SetIntegerVariable(parameter, value); }
    public void GetStateFloat(string parameter) { var value = state.GetFloat(parameter); flow.SetFloatVariable(parameter, value); }

    public void SetStateBool (string parameter, bool value) { state.SetBool(parameter, value); }
    public void SetStateInt(string parameter, int value) { state.SetInteger(parameter, value); }
    public void SetStateTrigger(string parameter) { state.SetTrigger(parameter); }
    public void SetStateFloat(string parameter, float value) { state.SetFloat(parameter, value); }


}
