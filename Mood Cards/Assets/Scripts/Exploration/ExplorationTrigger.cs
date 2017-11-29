using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ExplorationTrigger : MonoBehaviour {
  Flowchart flowchart;
    public string BlockName;
    public float interactionDistance;
    public bool disableAfterTrigger = true;

    ExplorationNav player;
    float dist;

    bool contact = false;

    public bool enter = false;

    // Use this for initialization
    void Start () {
        flowchart = FindObjectOfType<Flowchart>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ExplorationNav>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
        if (contact && !enter)
        {
            flowchart.ExecuteBlock(BlockName);
            if (disableAfterTrigger)
            {
                DisableTrigger();
            }
            enter = true;
        }else if (!contact)
        {
            enter = false;
        }
	}


    void CheckDistance()
    {

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < interactionDistance)
        {
            contact = true;
        }
        else
        {
            contact = false;
        }
    }

    public void EnableTrigger()
    {
        GetComponent<ExplorationTrigger>().enabled = true;
    }

    public void DisableTrigger()
    {
        GetComponent<ExplorationTrigger>().enabled = false;
    }
}
