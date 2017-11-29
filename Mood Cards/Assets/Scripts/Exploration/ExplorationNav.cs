using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class ExplorationNav : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public float dist;
    Animator ani;
    [HideInInspector]
    public Vector3 targetPoint;

    public ParticleSystem movePar;
    public GameObject hoverPar;

    public bool followMouse = true;

    public bool movementLock;

    [HideInInspector]
    public bool cutLock;

    [HideInInspector]
    public CinemachineFollowZoom zoom;

    float maxWidth = 20;
    float minWidth = 1;
    public float zoomLevel;
    private float vel;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        zoom = FindObjectOfType<CinemachineFollowZoom>();
        
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !movementLock)
        {
            if (cutLock) { cutLock = false; }
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (!hit.collider.isTrigger)
                {
                    NavMeshHit nav;
                    if (NavMesh.SamplePosition(hit.point, out nav, 0.5f, NavMesh.AllAreas))
                    {
                        agent.destination = hit.point;
                        targetPoint = hit.point;
                        movePar.transform.position = hit.point;
                        movePar.Emit(1);
                        UpdateZoom();
                    }
                }

            }
        }
        else if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && !movementLock && !cutLock)
        {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (!hit.collider.isTrigger)
                {
                    agent.destination = hit.point;
                    targetPoint = hit.point;
                    movePar.transform.position = hit.point;
                    //movePar.Emit(1);
                    UpdateZoom();
                }

            }
        }
            CheckIfStopped();

            if (!movementLock)
            {
                MouseHoverEffect();
                hoverPar.SetActive(true);
            }
            else
            {
                hoverPar.SetActive(false);
            }

    }

    void MouseHoverEffect()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            NavMeshHit nav;
            if (NavMesh.SamplePosition(hit.point, out nav, 0.5f, NavMesh.AllAreas))
            {
                hoverPar.transform.position = hit.point;
                hoverPar.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                hoverPar.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    void CheckIfStopped()
    {
        if (agent.pathPending)
        {
            dist = Vector3.Distance(transform.position, targetPoint);
        }
        else
        {
            dist = agent.remainingDistance;
        }

        if (dist < 1)
        {
            ani.SetTrigger("isIdle");
        }
        else
        {
            ani.SetTrigger("isMoving");
        }
    }

    public void SetMoveLock(bool set)
    {
        movementLock = set;
        if (movementLock)
        {
            agent.destination = transform.position;
        }
    }
    public void TurnTowards(Transform turn)
    {
        agent.destination = Vector3.MoveTowards(transform.position, turn.transform.position, 1);
    }

    public void MoveTo(Transform target)
    {
        agent.destination = target.position;
    }

    void UpdateZoom()
    {
        if (followMouse)
        {
            var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
            var targetScreenPoint = Camera.main.WorldToScreenPoint(targetPoint);

            playerScreenPoint.z = 0;
            targetScreenPoint.z = 0;

            var dist = Vector3.Distance(playerScreenPoint, targetScreenPoint);
            var percent = dist / (Screen.width / 2);

            zoomLevel = Mathf.SmoothDamp(zoomLevel, Mathf.Lerp(minWidth, maxWidth, percent), ref vel, 0.5f);

            zoom.m_Width = zoomLevel;
        }
    }
}
