using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigateAroundLoop : MonoBehaviour {
    [HideInInspector]
    public List<Transform> pointList;
    public bool cycle;
    public bool isMoving = true;
 
    [HideInInspector]
    public int currentPoint;
    [HideInInspector]
    public Transform targetPoint;
    int pointListSize;

    NavMeshAgent agent;
    public Transform PathPointHolder;
    Animator ani;
    float dist;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        currentPoint = 0;
        ani = GetComponent<Animator>();

        //Populate list

        foreach (Transform child in PathPointHolder)
        {
            pointList.Add(child);
        }
        pointListSize = pointList.Count;

        //Initialize movement
        targetPoint = pointList[currentPoint];
        if (isMoving)
        {
            agent.destination = targetPoint.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            Navigate();
        }else
        {
            CheckIfStopped();
        }
    }

    void Navigate()
    {
        if (agent.pathPending)
        {
            dist = Vector3.Distance(transform.position, targetPoint.position);
        }
        else
        {
            dist = agent.remainingDistance;
        }

        if (dist < 1)
        {
            if (currentPoint < pointListSize - 1)
            {
                currentPoint++;
            }
            else if (cycle)
            {
                currentPoint = 0;
            }
            else if (!cycle)
            {
                ani.SetTrigger("isIdle");
            }
            targetPoint = pointList[currentPoint];
            agent.destination = targetPoint.position;
        } else
        {
            ani.SetTrigger("isMoving");
        }
    }

    public void ToggleMoving()
    {
        isMoving = !isMoving;
        if (isMoving)
        {
            ani.SetTrigger("isMoving");
        }
    }

    void CheckIfStopped()
    {
        if (agent.pathPending)
        {
            dist = Vector3.Distance(transform.position, targetPoint.position);
        } else {
            dist = agent.remainingDistance;
        }

        if (dist < 1)
        {
            ani.SetTrigger("isIdle");
        } else {
           ani.SetTrigger("isMoving");
        }
    }

    public void TargetOverride(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
