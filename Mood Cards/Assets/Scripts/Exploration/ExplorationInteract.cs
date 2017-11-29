using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class ExplorationInteract : MonoBehaviour {
    Flowchart flowchart;
    public string BlockName;
    [HideInInspector]
    public string PeacePower;
    [HideInInspector]
    public string JoyPower;
    [HideInInspector]
    public string WonderPower;
    [HideInInspector]
    public string DespairPower;
    [HideInInspector]
    public string FearPower;
    [HideInInspector]
    public string RagePower;

    EmotionWheel power;

    public float interactionDistance = 2;

    ExplorationNav player;
    float dist;

    bool contact = false;
    bool executeOnContact = false;

    public ParticleSystem hoverParticle;

    // Use this for initialization
    void Start () {
        flowchart = FindObjectOfType<Flowchart>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ExplorationNav>();
        power = FindObjectOfType<EmotionWheel>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
        if (contact && executeOnContact)
        {
            if (power != null)
            {
                switch (power.CurrentlySelectedPower)
                {
                    case "Peace": flowchart.ExecuteBlock(PeacePower); break;
                    case "Joy": flowchart.ExecuteBlock(JoyPower); break;
                    case "Wonder": flowchart.ExecuteBlock(WonderPower); break;
                    case "Despair": flowchart.ExecuteBlock(DespairPower); break;
                    case "Fear": flowchart.ExecuteBlock(FearPower); break;
                    case "Rage": flowchart.ExecuteBlock(RagePower); break;
                    default: flowchart.ExecuteBlock(BlockName); break;
                }
            }
            else
            {
                flowchart.ExecuteBlock(BlockName);
            }
            executeOnContact = false;
        }
	}

    private void OnMouseDown()
    {
        if (!player.movementLock)
        {
            if (contact)
            {
                if (power != null)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        switch (power.CurrentlySelectedPower)
                        {
                            case "Peace": flowchart.ExecuteBlock(PeacePower); break;
                            case "Joy": flowchart.ExecuteBlock(JoyPower); break;
                            case "Wonder": flowchart.ExecuteBlock(WonderPower); break;
                            case "Despair": flowchart.ExecuteBlock(DespairPower); break;
                            case "Fear": flowchart.ExecuteBlock(FearPower); break;
                            case "Rage": flowchart.ExecuteBlock(RagePower); break;
                            default: flowchart.ExecuteBlock(BlockName); break;
                        }
                    }
                }
                else
                {
                    flowchart.ExecuteBlock(BlockName);
                }
                executeOnContact = false;
            }
            else
            {
                executeOnContact = true;
            }
        } 
    }

    private void OnMouseOver()
    {
        if (!player.movementLock)
        {
            var em = hoverParticle.emission;
            em.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        var em = hoverParticle.emission;
        em.enabled = false; 
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
}
