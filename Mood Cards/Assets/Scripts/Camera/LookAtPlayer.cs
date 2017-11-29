using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Transform mainCamera;
    public Transform tracker;

    public bool allowLiveTracking = true;

    public int Boundary = 100;
    //public int speed = 50;
    public float trackSpeed;
    public float hardness = 1;

    private int ScreenWidth;
    private int ScreenHeight;
    private Vector3 myVector;

    [HideInInspector]
    public bool follow;
    bool inDeadzone;
    float offscreenModifier;
    Vector3 offset;
    private float smoothVelocity = 0.0f;
    private float trackVelocity = 0.0f;

    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    void Update()
    {
        // Never uncomment this line
        //Camera.main.transform.LookAt(player);
        Camera.main.transform.LookAt(tracker);


        // Uncomment each one and see how it feels. Let me know if you want me to adjust anything!

        //** NUMBER ONE **// - Moves camera when mouse in on the edge of the screen
        //if (Input.mousePosition.x > ScreenWidth - Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.up, 1.0f);
        //}
        //if (Input.mousePosition.x < 0 + Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.down, 1.0f);
        //}

        //** NUMBER TWO **// - Moves the camera when place reaches the edge of the screen
        //Vector3 playerPosition;
        //playerPosition = Camera.main.WorldToScreenPoint(player.position);

        //if (playerPosition.x > ScreenWidth - Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.up, 1.0f);
        //}
        //if (playerPosition.x < 0 + Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.down, 1.0f);
        //}

        //if (playerPosition.y > ScreenHeight - Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.up, 1.0f);
        //}

        //if (playerPosition.y < 0 + Boundary)
        //{
        //    mainCamera.RotateAround(player.position, Vector3.down, 1.0f);
        //}

        //** NUMBER 2.5 **// - Tracks gameobject and locks to player movement when boundary is reached


        Vector3 playerPosition;
        playerPosition = Camera.main.WorldToScreenPoint(player.position);
        var playerAgent = player.GetComponent<ExplorationNav>().agent;
        var dest = Camera.main.WorldToScreenPoint(playerAgent.destination);



        if (playerPosition.x > ScreenWidth - Boundary)
        {
            inDeadzone = true;
            if (dest.x > ScreenWidth - Boundary)
            {
                follow = true;
            }
        }
        else if (playerPosition.x < 0 + Boundary)
        {
            inDeadzone = true;
            if (dest.x < 0 + Boundary)
            {
                follow = true;
            }
        }
        else if (playerPosition.y > ScreenHeight - Boundary)
        {
            inDeadzone = true;
            if (dest.y > ScreenHeight - Boundary)
            {
                follow = true;
            }
        }
        else if (playerPosition.y < 0 + Boundary)
        {
            inDeadzone = true;
            if (dest.y < 0 + Boundary)
            {
                follow = true;
            }
        }
        else
        {
            inDeadzone = false;
            follow = false;
        }

        if (playerAgent.remainingDistance < 0.5) { follow = false; }

        if (follow)
        {
            var tx = Mathf.SmoothDamp(tracker.transform.position.x, player.transform.position.x + offset.x, ref trackVelocity, hardness);
            var ty = Mathf.SmoothDamp(tracker.transform.position.y, player.transform.position.y + offset.y, ref trackVelocity, hardness);
            var tz = Mathf.SmoothDamp(tracker.transform.position.z, player.transform.position.z + offset.z, ref trackVelocity, hardness);
            tracker.transform.position = new Vector3(tx, ty, tz);
        } else
        {
            offset = tracker.transform.position - player.transform.position;
        }

        offscreenModifier = inDeadzone ? Mathf.SmoothDamp(offscreenModifier, 5, ref smoothVelocity, hardness) : Mathf.SmoothDamp(offscreenModifier, 1, ref smoothVelocity, hardness);


        if (allowLiveTracking)
        {
            float step = trackSpeed * Time.deltaTime;
            tracker.transform.position = Vector3.MoveTowards(tracker.transform.position, player.transform.position, step * offscreenModifier);
        }

        //** NUMBER THREE **// - Key input to move the camera [ and ]
        //if (Input.GetKey("["))
        //{
        //    transform.RotateAround(player.position, Vector3.up, 1.5f);
        //}
        //if (Input.GetKey("]"))
        //{
        //    transform.RotateAround(player.position, Vector3.down, 1.5f);
        //}
    }

    public void EnableLiveTracking (bool track){
        allowLiveTracking = track;
        }
}
