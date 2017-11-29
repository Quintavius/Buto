using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSnapTo : MonoBehaviour
{
    private Vector3 vel;
    [HideInInspector]
    public bool move;
    GameObject moveTarget;
    Transform player;

    public bool avoidPlayer = true;
    public float SmoothTime;
    public float MaxSpeed;
    public float MinPlayerDistance = 3;

    private float hDamp = 0.8f;
    private float vDamp = 1;
    CinemachineComposer cin;

    private float dampVel;
    bool cutWhenReady;
    Transform look;
    Transform cutTarget;

    // Use this for initialization
    void Start()
    {
        cin = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        player = GameObject.Find("Buto_Exploration").transform;
        look = GameObject.Find("Tracker").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cin.m_HorizontalDamping == 0 ||
    cin.m_VerticalDamping == 0)
        {
            cin.m_HorizontalDamping = Mathf.SmoothDamp(cin.m_HorizontalDamping, hDamp, ref dampVel, 0.5f);
            cin.m_VerticalDamping = Mathf.SmoothDamp(cin.m_VerticalDamping, vDamp, ref dampVel, 0.5f);
        }

        if (move)
        {
            transform.position = Vector3.SmoothDamp(transform.position, moveTarget.transform.position, ref vel, SmoothTime, MaxSpeed);
            //if (avoidPlayer) fucking trash but i'm too scared to delete it
            //{
            //    var dir = -transform.forward;
            //    if (!Physics.Raycast(transform.position, dir, MinPlayerDistance)) //This is garbage, get move direction instead
            //    {

            //        var oldY = transform.position.y;
            //        var newPos = Vector3.MoveTowards(transform.position, player.transform.position, -0.01f);
            //        transform.position = new Vector3(newPos.x, oldY, newPos.z);
            //    }
            //}
            var dist = Vector3.Distance(transform.position, moveTarget.transform.position);
            if (dist < 0.5f)
            {
                move = false;
            }
        }

        if (cutWhenReady)
        {
            cin.m_HorizontalDamping = 0;
            cin.m_VerticalDamping = 0;
            move = false;
            transform.position = cutTarget.position;
            transform.rotation = cutTarget.rotation;
            cutWhenReady = false;
        }

    }

    public void SnapTo(GameObject target)
    {
        RaycastHit hit;

        var dir = target.transform.position - transform.position;
        if (Physics.Raycast(transform.position, dir, out hit))
        {
            if (hit.transform.tag == "CameraPoint")
            {
                moveTarget = target;
                move = true;
            }
            else
            {
                CutTo(target.transform);
            }
        }
        //Camera.main.transform.rotation = target.transform.rotation;
    }

    public void CutTo(Transform target)
    {
        player.GetComponent<ExplorationNav>().cutLock = true;
        cutTarget = target;
        if (!move)
        {
            cin.m_HorizontalDamping = 0;
            cin.m_VerticalDamping = 0;
            move = false;
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
        else
        {
            cutWhenReady = true;
        }
    }

    public void LookAtThis(GameObject target)
    {
            look.parent = target.transform;
            look.transform.localPosition = new Vector3(0, 0, 0);
    }


}
