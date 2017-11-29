using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [Header("Character Values")]
    public Animator ani;
    public float moveSpeed = 1;
    public float lookSpeed = 1;
    float hVelocity = 0f;
    float vVelocity = 0f;
    [SerializeField]
    [Range(0f, 3f)]
    public float lerpSpeed = 0.02f;

    float hSpeed;
    float vSpeed;
    float hLook;
    float vLook;
    CharacterController controller;
    Vector3 moveDir;
    Vector3 lookDir;
    float hMod = 0f;
    float vMod = 0f;

    bool triggerAniChange = false;

    // Use this for initialization
    void Start () {
        //Grab controller
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        hSpeed = Input.GetAxis("Horizontal");
        vSpeed = Input.GetAxis("Vertical");
        if (hSpeed != 0 || vSpeed != 0)
        {
            MovePlayer();
        }
        else
        {
            if (triggerAniChange)
            {
                ani.SetTrigger("isMoving");
                triggerAniChange = false;
            }
        }

        hLook = Input.GetAxis("LookHorizontal");
        vLook = Input.GetAxis("LookVertical");
        if (hLook != 0 || vLook != 0)
        {
            RotateCamera();
        }
    } 

    void MovePlayer()
    {
        moveDir = new Vector3(0, 0, 0);
        if (Mathf.Abs(hSpeed) == 1 && Mathf.Abs(vSpeed) == 1)
        {
            //Keyboard Hack
            moveDir = new Vector3(hSpeed * 0.75f, 0, vSpeed * 0.75f);
        }
        else
        {
            moveDir = new Vector3(hSpeed, 0, vSpeed);
        }
        moveDir = Camera.main.transform.TransformDirection(moveDir);
        controller.SimpleMove(moveDir * moveSpeed);                      //holy shit we movin

        Vector3 movement = new Vector3(hSpeed, 0.0f, vSpeed);
        Vector3 rotateDir = moveDir = Camera.main.transform.TransformDirection(movement) ;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateDir.normalized), 0.5f); ;


        ani.SetTrigger("isMoving");

    }

    void RotateCamera()
    {


    }
}
