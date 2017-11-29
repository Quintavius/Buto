using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapPositionManager : MonoBehaviour {
    public Transform player;
    public Vector3 playerPosition;
    NavMeshAgent agent;
    


	// Use this for initialization
	void Awake () {
        agent = player.GetComponent<NavMeshAgent>();
        playerPosition = new Vector3(MapPointHolder.X, MapPointHolder.Y, MapPointHolder.Z);
        if (playerPosition != Vector3.zero)
        {
            agent.Warp(playerPosition);
        }
        else
        {
            MapPointHolder.X = player.position.x;
            MapPointHolder.Y = player.position.y;
            MapPointHolder.Z = player.position.z;
        }
    }

    private void Start(){
    }
	
	// Update is called once per frame
	void Update () {
        MapPointHolder.X = player.position.x;
        MapPointHolder.Y = player.position.y;
        MapPointHolder.Z = player.position.z;
    }

}
