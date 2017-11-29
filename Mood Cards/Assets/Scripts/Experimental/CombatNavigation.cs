using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatNavigation : MonoBehaviour {
    //public Transform player;

    public float maxDistance = 2;
    public float stoppingDistance;

    [Space(10)]
    public bool FollowTarget = false;
    public Transform follow;

    [Header("Hidden Variables")]
    NavMeshAgent agent;
    Vector3 goal;
    Vector3 oldPos;
    Vector3 targetDir;
    Vector3 targetPos;
    float dist;
    Animator ani;
    bool moving;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        goal = transform.position;
        ani = GetComponent<Animator>();

        dist = Vector3.Distance(transform.position, follow.position);

    }

    // Update is called once per frame
    void Update()
    {
        goal = transform.position;

        if (FollowTarget)
        {
            FollowUpdate();
        }

        if (moving)
        {
            MoveUpdate();
        }
    }
    public void MoveEnemyTowards(Transform target)
    {
        oldPos = goal;
        //Get direction
        targetPos = target.position;
        targetDir = targetPos - transform.position;
        //Apply
        goal = oldPos + (targetDir.normalized * (maxDistance)); //divide max dist by 2 to compensate for double moods
        agent.destination = goal;
    }

    public void MoveEnemy(Transform moveTarget)
    {
        agent.destination = moveTarget.position;
        moving = true;
    }

    void FollowUpdate()
    {
        dist = Vector3.Distance(transform.position, follow.position);

        if (dist < stoppingDistance) //Reached goal
        {
            agent.destination = transform.position;
            ani.SetTrigger("isIdle");

        }
        else //still moving
        {
            agent.destination = follow.position;
            ani.SetTrigger("isMoving");
        }
    }

    void MoveUpdate()
    {
        if (!agent.pathPending)
        {
            dist = Vector3.Distance(transform.position, agent.destination);

            if (dist < stoppingDistance) //Reached goal
            {
                ani.SetTrigger("isIdle");
                moving = false;
            }
            else //still moving
            {
                ani.SetTrigger("isMoving");
            }
        }
    }

    public void FollowOverride(bool enableFollow, Transform target)
    {
        FollowTarget = enableFollow;
        follow = target;
    }

    public void WarpTo(Transform target)
    {
        agent.Warp(target.position);
    }

    public void PriorityOverride(int priority)
    {
        agent.avoidancePriority = priority;
    }
}
