using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimator : MonoBehaviour {
    public Renderer rend;
    public int faceMaterialIndex = 0;

    [HideInInspector]
    public bool forceEyesClosed = false;
    [HideInInspector]
    public bool isTalking;
    [HideInInspector]
    public bool isLooking;

    public float gapDuration;
    public float blinkDuration;


    public Transform faceBone;
    public Transform baseBone;
    public Transform headBone;
    Transform lookTarget;
    Vector3 eyesOpenMouthOpen;
    Vector3 eyesOpenMouthClosed;
    Vector3 eyesClosedMouthOpen;
    Vector3 eyesClosedMouthClosed;

    public GameObject dialog;

    //mouth position, eye position
    float yStart;
    float xStart;
    float yOffset;
    float xOffset;

    //Blinking timers
    float t_gap;
    float t_blink;
    bool gapTimer_running;
    bool blinkTimer_running;
    float randomMod;

    //Talking timers
    float t_talkgap;
    float t_talk;
    bool talkgapTimer_running;
    bool talkTimer_running;

    bool Eyes; //True if open
    bool Mouth; //True if open
    bool aniMouth;

    ExplorationNav nav;
    Transform hover;

    Quaternion lastLook;
    private Vector3 lookVel;
    Quaternion nextLook;
    Quaternion originalLook;
    public bool lookWhereYoureGoing = false;
    public bool freeRoamLookOverride = false;
    public Transform freeRoamLookTarget;

    // Use this for initialization
    void Awake () {
        //Fill job openings
        //faceBone = transform.Find("MainRig/face_main/FaceControl");
        //baseBone = transform.Find("MainRig/face_main/test_base");

        //How far should things move
        eyesClosedMouthOpen = new Vector3(faceBone.localPosition.x + 0.5f, faceBone.localPosition.y - 0.5f, faceBone.localPosition.z);
        eyesOpenMouthOpen = new Vector3(faceBone.localPosition.x, faceBone.localPosition.y - 0.5f, faceBone.localPosition.z);
        eyesClosedMouthClosed = new Vector3(faceBone.localPosition.x + 0.5f, faceBone.localPosition.y, faceBone.localPosition.z);
        eyesOpenMouthClosed = new Vector3(faceBone.localPosition.x, faceBone.localPosition.y, faceBone.localPosition.z);



        yStart = faceBone.localPosition.y;
        xStart = faceBone.localPosition.x;
        yOffset = faceBone.localPosition.y + 0.5f;
        xOffset = faceBone.localPosition.x + 0.5f;

        t_talk = blinkDuration/2;
        t_blink = blinkDuration;
        randomMod = Random.Range(gapDuration * -1, gapDuration);
    }

    private void Start()
    {
        nav = FindObjectOfType<ExplorationNav>();
        hover = nav.hoverPar.transform;
    }

    public void ForceEyesClosed (bool isClosed) {
        forceEyesClosed = isClosed;
    }

    public void SetTalking (bool talking)
    {
        isTalking = talking;
        if (talking == false)
        {
            Mouth = false;
        }
    }

    private void Update()
    {
        AutoTalk();
    }

    private void LateUpdate()
    {
        originalLook = headBone.transform.rotation;
        FixBlend();
        Blink();
        if (isTalking) { Talk(); }
        if (isLooking) { Look(); }
        if (!nav.movementLock && lookWhereYoureGoing) { LookAtMouse(); }
        if (freeRoamLookOverride) { FreeRoamLook(); }


        //Force eyes shut
        if (forceEyesClosed)
        {
            Eyes = false;
        }

        //apply all 
        if (Eyes)
        {
            if (Mouth)
            {
                faceBone.localPosition = eyesOpenMouthOpen;
            }
            else
            {
                faceBone.localPosition = eyesOpenMouthClosed;
            }
        }
        else
        {
            if (Mouth)
            {
                faceBone.localPosition = eyesClosedMouthOpen;
            }
            else
            {
                faceBone.localPosition = eyesClosedMouthClosed;
            }
        }

            //Get things moving
            Vector3 offset = baseBone.InverseTransformPoint(faceBone.position);

        var faceMat = rend.materials[faceMaterialIndex];
        faceMat.SetTextureOffset("_BaseMap", new Vector2(offset.x, offset.y));
        faceMat.SetTextureOffset("_1st_ShadeMap", new Vector2(offset.x, offset.y));
        faceMat.SetTextureOffset("_2nd_ShadeMap", new Vector2(offset.x, offset.y));
    }


    public void Blink()
    {
        //gap timer has run out, start blink
        if (t_gap >= gapDuration + randomMod)
        {
            gapTimer_running = false;
            blinkTimer_running = true;
            t_gap = 0;
            randomMod = Random.Range(gapDuration * -1, gapDuration);
        }

        //blink timer has run out, trigger gap timer and open eyes
        if (t_blink >= blinkDuration)
        {
            //faceBone.localPosition = eyesOpen;
            gapTimer_running = true;
            blinkTimer_running = false;
            t_blink = 0;
        }

        if (gapTimer_running) { t_gap += Time.deltaTime; }
        if (blinkTimer_running) {
            //faceBone.localPosition = eyesClosed;
            Eyes = false;
            t_blink += Time.deltaTime; }

        //keep counting

    }

    void FixBlend()
    {
        if (faceBone.localPosition.x <= xOffset -0.48)
        {
            if (faceBone.localPosition.y <= yStart - 0.02)
            {
                faceBone.localPosition = new Vector3(xStart, yOffset, faceBone.localPosition.z);
                Eyes = true;
                //Mouth = true;
            }
            else
            {
                faceBone.localPosition = new Vector3(xStart, yStart, faceBone.localPosition.z);
                Eyes = true;
                //Mouth = false;
            }
        }
        else if (faceBone.localPosition.y <= yStart - 0.02)
        {
            faceBone.localPosition = new Vector3(xOffset, yOffset, faceBone.localPosition.z);
            Eyes = false;
            //Mouth = true;
        }
        else
        {
            faceBone.localPosition = new Vector3(xOffset, yStart, faceBone.localPosition.z);
            Eyes = false;
            //Mouth = false;  
        }

    }

    void Talk()
    {
        if (t_talk >= (gapDuration / 24f) + (randomMod/24))
        {
            Mouth = !Mouth;
            if (Mouth) {aniMouth = true;} else { aniMouth = false; }
            t_talk = 0;
            randomMod = Random.Range(gapDuration * -1, gapDuration);
        }
        else
        {
            t_talk += Time.deltaTime;
        }
    }

    public void ForceLookAt(bool look, Transform target)
    {
        isLooking = look;
        if (target != null)
        {
            lookTarget = target;
        }
    }

    void Look()
    {
        //Compensate for the mouse being directly on the ground
        var hoverMod = 0f;
        if (lookTarget == hover)
        {
            hoverMod = 0.6f;
        }
       
        var dir = lookTarget.position - transform.position;

        //What's the angle I'm looking at
        var angle = Mathf.Abs(Vector3.Angle(transform.forward, dir));
        if (angle < 75)
        {
            //ENGAGE LOOK ACTIVITIES
            var originalLook = headBone.transform.rotation; //store position of animation
            headBone.transform.LookAt(new Vector3(lookTarget.position.x,lookTarget.position.y+hoverMod,lookTarget.position.z), transform.right); //snap to new pos
            nextLook = headBone.transform.rotation; //write new pos in variable
            nextLook = Quaternion.Lerp(originalLook, nextLook, 0.5f);
            nextLook = Quaternion.LerpUnclamped(originalLook, nextLook, 2f); //Extrapolate based on animation
            headBone.transform.rotation = lastLook; //reset to old position
            headBone.transform.rotation = Quaternion.Lerp(lastLook, nextLook, Time.deltaTime * 3); //apply lerped position
            lastLook = headBone.transform.rotation; //store current for next round so we can lerp
        }
        else
        {
            //headBone.transform.rotation = lastLook;
            headBone.transform.rotation = Quaternion.Lerp(lastLook, originalLook, Time.deltaTime * 2); //This one will lerp to original animation
            lastLook = headBone.transform.rotation;
        }
    }

    void LookAtMouse()
    {

        ForceLookAt(true, hover);
    }

    void FreeRoamLook()
    {
        ForceLookAt(true, freeRoamLookTarget);
    }

    void AutoTalk()
    {
        if (dialog.activeSelf)
        {
            SetTalking(true);
        }
        else
        {
            SetTalking(false);
        }
    }
}
