using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hacky and disgusting, take this out after armageddon
public class StateMachineOverride : MonoBehaviour {
    public Animator stateMachine;
    [Header("Hacky and Bad")]
    public bool gornAngry;
    public bool builderButo;
    public bool peaceFollowing;
    public bool idgafCartInteracted;
    public bool doorUnlocked;
    public int builderUnlocked;
    public bool teaShopChecker;


	// Use this for initialization
	void Start () {
        stateMachine = GameObject.Find("StateMachine").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        stateMachine.SetBool("GornAngry", gornAngry);
        stateMachine.SetBool("BuilderButo", builderButo);
        stateMachine.SetBool("PeaceFollowing", peaceFollowing);
        stateMachine.SetBool("IdgafCartInteracted", idgafCartInteracted);
        stateMachine.SetBool("DoorUnlocked", doorUnlocked);
        stateMachine.SetBool("TeaShopChecker", teaShopChecker);
        stateMachine.SetInteger("BuilderUnlocked", builderUnlocked);
    }
}
