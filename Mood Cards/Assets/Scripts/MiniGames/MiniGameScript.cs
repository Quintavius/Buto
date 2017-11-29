using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;
using System;

public class MiniGameScript : MonoBehaviour
{
    private float GameTimer;

    [Header("Game Panels")]
    public GameObject[] GamePanels;
    [Space(10)]

    [Header("Rage")]
    public Image RageFillFront;
    public float RageDrainRate;
    public float RageFillAmount;

    private float RageFill;
    private float RageTarget;
    private float RageTimer;
    private bool RageTrigger;
    private bool isRageOn;
    [Space(10)]

    [Header("Despair")]
    public Image DespairFillFront;
    private float DespairFill;
    private bool DespairTrigger;
    private bool isDespairOn;
    public Animator dropAnimator;
    [Space(10)]

    [Header("Joy")]
    public Image JoyFillFront;
    public GameObject JoyBar;
    public GameObject JoyObject;
    [HideInInspector]
    public bool JoyColliding;

    private float JoyTimer;
    private float JoyRandTimer;
    private float JoyLerp;
    private float JoySpeed;
    private float JoyMaxSpeed;
    private float JoyAcc;
    private float JoyDec;
    private int JoyDir;
    private bool isJoyOn;
    [Space(10)]

    [Header("Wonder")]
    public Image WonderFillFront;
    public Slider WonderSlider;
    public GameObject WonderBlobObject;
    public Sprite WonderBlob;
    public Sprite WonderSquash;

    private float WonderFill;
    private float WonderTimer;
    private bool WonderTrigger;
    private float WonderLerpValue;
    private bool isWonderOn;
    private bool isRight;
    [Space(10)]

    [Header("Fear")]
    public GameObject FearBlock;
    public GameObject FearPiecePrefab;
    public Transform[] FearSpawnPoints;
    public float FearDelay = 1.0f;
    public float FearSpeed = 500.0f;
    private bool isFearOn;
    public int playerLives;
    [Space(10)]

    [Header("Peace")]
    [HideInInspector]
    public List<GameObject> PeaceButtons;
    public GameObject PeaceButtonPrefab;
    public GameObject PeaceLinePrefab;
    public GameObject PeaceButtonsGroup;
    public GameObject PeaceLineGroup;
    public int PeaceNum;
    [HideInInspector]
    public bool isPeaceOn;

    private float connectionLength;
    private bool runOnce;

    //Lerping
    private float vel;
    //Flowchart
    private string winBlock;

    void Start()
    {
        PeaceButtons = new List<GameObject>();
        PeaceNum = 6;
        WonderFill = WonderSlider.value * 100;
        JoyFillFront.fillAmount = 0;
    }

    void Update()
    {
        InputUpdate();
        TimerUpdate();

        // Emotion update functions
        if (isRageOn) { RageUpdate(); }
        if (isFearOn) { FearUpdate(); }
        if (isDespairOn) { DespairUpdate(); }
        if (isJoyOn) { JoyUpdate(); }
        if (isWonderOn) { WonderUpdate(); }
        if (isPeaceOn) { PeaceUpdate(); }
    }

    private void InputUpdate()
    {
        // change mood game here for testing
        if (Input.GetKeyDown(KeyCode.F1))
        {
            EnableFear();
        }

        if (isDespairOn)
        {
            DespairInput();
        }
    }
        

    private void TimerUpdate()
    {
        GameTimer += Time.deltaTime;
        RageTimer += Time.deltaTime;
        WonderTimer += Time.deltaTime;
        JoyTimer += Time.deltaTime;
    }

    // RAGE  
    private void RageUpdate()
    {
        // Rage Gauge
        RageTarget -= RageDrainRate * Time.deltaTime;
        if (RageFill < 0)
        {
            RageFill = 0;
        }
        else if (RageFill > 100)
        {
            //RageFill = 100;
            var flow = FindObjectOfType<Flowchart>();
            flow.ExecuteBlock(winBlock);
            DisableAll();
        }
        RageFillFront.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(0f, 500.0f, RageFill / 100), Mathf.Lerp(0f, 500.0f, RageFill / 100));

        RageFill = Mathf.SmoothDamp(RageFill, RageTarget, ref vel, 10 * Time.deltaTime);
    }

    public void RageButton()
    {
        RageTarget = RageFill + RageFillAmount;
    }


    // DESPAIR
    private void DespairUpdate()
    {
        // Despair Gauge
        DespairFill -= 0.5f;
        if (DespairFill < 0)
        {
            DespairFill = 0;
        }
        else if (DespairFill > 100)
        {
            DespairFill = 100;
        }

        DespairFillFront.fillAmount = Mathf.Lerp(0f, 1.0f, DespairFill / 100);

        if (DespairTrigger)
        {
            DespairFill += 0.8f;
        }
    }
    public void DespairInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dropAnimator.SetBool("MouseDown", true);
            DespairTrigger = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DespairTrigger = false;
            dropAnimator.SetBool("MouseDown", false);
        }
    }


    // JOY
    public void JoyUpdate()
    {
        if (isJoyOn)
        {
            JoyInput();
            JoyAI();

            if (JoyColliding)
            {
                JoyFillFront.fillAmount += 0.002f;
            }
            else
            {
                JoyFillFront.fillAmount -= 0.002f;
            }
        }
    }

    public void JoyInput()
    {
        Vector3 JoyBlockPos = JoyBar.transform.position;
        if (Input.GetMouseButton(0)) // left mouse click
        {
            Vector3 top = new Vector3(300f, 290f);

            JoyBar.transform.position = Vector2.MoveTowards(JoyBlockPos, top, 0.25f);
        }
        else
        {
            Vector3 bottom = new Vector3(300f, 130f);
            JoyBar.transform.position = Vector2.MoveTowards(JoyBlockPos, bottom, 0.25f);
        }

    }

    public void JoyAI()
    {
        Vector3 JoyObjectPos = JoyObject.transform.position;
        Vector3 top = new Vector3(300f, 290f);
        Vector3 bottom = new Vector3(300f, 130f);

        if (!runOnce)
        {
            Debug.Log("Start");

            JoyTimer = 0;

            // UnityEngine.Randomize timerc
            JoyRandTimer = UnityEngine.Random.Range(0.1f, 1.0f);

            // UnityEngine.Randomize speed
            JoyMaxSpeed = UnityEngine.Random.Range(0.05f, 0.15f);

            // UnityEngine.Randomize direction
            JoyDir = UnityEngine.Random.Range(0, 2);


            JoyAcc = JoyMaxSpeed;
            JoyDec = JoyMaxSpeed;

            runOnce = true;
        }

        if (JoyTimer < JoyRandTimer)
        {
            JoySpeed = JoySpeed + (JoyAcc * 0.005f);

            if (JoyMaxSpeed > JoySpeed)
            {
                Debug.Log("Too fast");
                JoySpeed = JoyMaxSpeed;
            }
        }
        else
        {
            JoySpeed = 0;
        }

        if (runOnce)
        {
            if (JoyObjectPos.y >= top.y - 0.5f)
            {
                Debug.Log("1");
                JoyDir = 1;
            }
            if (JoyObjectPos.y >= top.y + 0.5f)
            {
                Debug.Log("0");
                JoyDir = 0;
            }

            else
            {
                if (JoyDir == 0)
                {
                    JoyObject.transform.position = Vector2.MoveTowards(JoyObjectPos, top, JoySpeed);
                    if (JoyObjectPos.y >= top.y)
                    {
                        JoyObjectPos = top;
                    }
                }

                else
                {
                    JoyObject.transform.position = Vector2.MoveTowards(JoyObjectPos, bottom, JoySpeed);
                    if (JoyObjectPos.y <= top.y)
                    {
                        JoyObjectPos = bottom;
                    }
                }
            }

        }


        if (JoyTimer > JoyRandTimer)
        {
            Debug.Log("End");
            runOnce = false;
        }
    }


    // WONDER
    public void WonderUpdate()
    {
        if (isWonderOn)
        {
            
            if (WonderFill >= 95)
            {
                WonderBlobObject.GetComponent<Image>().sprite = WonderSquash;
                WonderBlobObject.transform.rotation = new Quaternion(0f, 0f, 180f, 0f);
            }
            else if (WonderFill <= 5)
            {
                WonderBlobObject.GetComponent<Image>().sprite = WonderSquash;
                WonderBlobObject.transform.rotation = new Quaternion(0f, 0f, 0f ,0f);
            }
            else
            {
                WonderBlobObject.GetComponent<Image>().sprite = WonderBlob;
                WonderBlobObject.transform.Rotate(Vector3.forward, 250 * Time.deltaTime);
            }


            if (isRight)
            {
                WonderFill += 0.5f;
                WonderSlider.value = WonderFill / 100;

                if (WonderFill >= 100)
                {
                    isRight = false;
                }
            }

            else if (!isRight)
            {
                WonderFill -= 0.5f;
                WonderSlider.value = WonderFill / 100;

                if (WonderFill <= 0)
                {
                    isRight = true;
                }
            }

            // animations here

        }

    }

    public void WonderButton()
    {
        WonderTrigger wonderTrigger = FindObjectOfType<WonderTrigger>();
        if (wonderTrigger.onCenter && WonderTimer > 0.6f)
        {
            WonderTrigger = true;
            WonderTimer = 0;
            WonderFillFront.fillAmount += 0.25f;
            //WonderFillFront.fillAmount = Mathf.Lerp(WonderFillFront.fillAmount + 0.25f, WonderFillFront.fillAmount,);
        }

    }


    // FEAR
    public void FearUpdate()
    {
        FearInput();

        if (GameTimer > 10)
        {
            Debug.Log("player survived 10 seconds, disable game");
            DisableAll();
            var flow = FindObjectOfType<Flowchart>();
            flow.ExecuteBlock("FearDone");
        }
    }

    public void FearInput()
    {
        // Checking bounds for mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1f;
        FearBlock.transform.position = mousePos;

        // If mouse x is far right
        {
            if (mousePos.x > FearSpawnPoints[1].position.x)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[1].position.x, mousePos.y);
            }
        }
    
        // If mouse x is far left   
        {
            if (mousePos.x < FearSpawnPoints[3].position.x)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[3].position.x, mousePos.y);
            }
        }

        // If mouse y is far top
        {
            if (mousePos.y > FearSpawnPoints[0].position.y)
            {
                FearBlock.transform.position = new Vector3(mousePos.x, FearSpawnPoints[0].position.y);
            }
        }

        // If mouse y is far bottom
        {
            if (mousePos.y < FearSpawnPoints[2].position.y)
            {
                FearBlock.transform.position = new Vector3(mousePos.x, FearSpawnPoints[2].position.y);
            }
        }

        // Top right corner
        {
            if (mousePos.x > FearSpawnPoints[1].position.x && mousePos.y > FearSpawnPoints[0].position.y)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[1].position.x, FearSpawnPoints[0].position.y);
            }
        }

        // Top left corner
        {
            if (mousePos.x < FearSpawnPoints[3].position.x && mousePos.y > FearSpawnPoints[0].position.y)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[3].position.x, FearSpawnPoints[0].position.y);
            }
        }

        // Bottom right corner
        {
            if (mousePos.x > FearSpawnPoints[1].position.x && mousePos.y < FearSpawnPoints[2].position.y)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[1].position.x, FearSpawnPoints[2].position.y);
            }
        }
        // Bottom left corner
        {
            if (mousePos.x < FearSpawnPoints[3].position.x && mousePos.y < FearSpawnPoints[2].position.y)
            {
                FearBlock.transform.position = new Vector3(FearSpawnPoints[3].position.x, FearSpawnPoints[2].position.y);
            }
        }

       
    }

    public void FearSpawn()
    {
        int randNum = UnityEngine.Random.Range(0, 4); // 0 = top, 1 = right, 2 = bottom, 3 = left

        GameObject fearPiece = Instantiate(FearPiecePrefab, FearSpawnPoints[randNum], false);

        if (randNum == 0) // top
        {
            fearPiece.transform.localPosition = new Vector3(UnityEngine.Random.Range(-450f, 450f), 0);
        }

        else if (randNum == 1) // right
        {
            fearPiece.transform.localPosition = new Vector3(0, UnityEngine.Random.Range(-453f, 453f));
            fearPiece.transform.Rotate(new Vector3(0, 0, -90f));
        }

        else if (randNum == 2) // bottom
        {
            fearPiece.transform.localPosition = new Vector3(UnityEngine.Random.Range(-453f, 453f), 0);
            fearPiece.transform.Rotate(new Vector3(0, 0, 180f));
            
        }

        else if (randNum == 3) // left
        {
            fearPiece.transform.localPosition = new Vector3(0, UnityEngine.Random.Range(-450f, 450f));
            fearPiece.transform.Rotate(new Vector3(0, 0, 90f));
        }
    }


    // PEACE
    public void PeaceUpdate()
    {
        PeaceSpawn();
    }

    public void PeaceSpawn()
    {
        if (!runOnce && isPeaceOn)
        {
            for (int i = 0; i < PeaceNum; i++)
            {
                GameObject peaceButton = Instantiate(PeaceButtonPrefab, PeaceButtonsGroup.transform, false);

                PeaceButtons.Add(peaceButton);
                CheckNeighbour(peaceButton);

                peaceButton.name = i.ToString();

                if (i == 0)
                {
                    PeaceButtons[0].transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                }
            }

            runOnce = true;
        }

        if (!isPeaceOn)
        {
            foreach (Transform child in PeaceButtonsGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void CheckNeighbour(GameObject peaceButton)
    {
        do
        {
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(-680f, 680), UnityEngine.Random.Range(350f, -350f), 0);
            Collider2D colliders = Physics2D.OverlapCircle(newPos, 500);
            

            if (!colliders)
            {
                Debug.Log("2");
                peaceButton.transform.localPosition = newPos;
                break;
            }

            Debug.Log("1");

        } while (true);
    }

    public void EnableRage(string WinBlock) { // RAGE

        winBlock = WinBlock;

        isRageOn = true;

        isDespairOn = false;
        isJoyOn = false;
        isWonderOn = false;
        isFearOn = false;
        isPeaceOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 0)
            {
                GamePanels[i].SetActive(true);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }
    }

    public void EnableDespair() {  // DESPAIR

        isDespairOn = true;

        isRageOn = false;
        isJoyOn = false;
        isWonderOn = false;
        isFearOn = false;
        isPeaceOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 1)
            {
                GamePanels[i].SetActive(true);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }

        dropAnimator = GameObject.Find("DespairDrop").GetComponent<Animator>();

    }

    public void EnableJoy() {  // JOY

        isJoyOn = true;
        isRageOn = false;
        isDespairOn = false;
        isWonderOn = false;
        isFearOn = false;
        isPeaceOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 2)
            {
                GamePanels[i].SetActive(true);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }
    }

    public void EnableWonder(){  // WONDER

        isWonderOn = true;
        isRageOn = false;
        isDespairOn = false;
        isJoyOn = false;
        isFearOn = false;
        isPeaceOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 3)
            {
                GamePanels[i].SetActive(true);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }
    }

    public void EnableFear(){ // FEAR

        isFearOn = true;
        isRageOn = false;
        isDespairOn = false;
        isJoyOn = false;
        isWonderOn = false;
        isPeaceOn = false;

        runOnce = false;

        CancelInvoke();

        GameTimer = 0;
        playerLives = 3;

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 4)
            {
                GamePanels[i].SetActive(true);
                InvokeRepeating("FearSpawn", FearDelay, FearDelay);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }
    }

    public void EnablePeace(){  // PEACE

        isPeaceOn = true;

        isRageOn = false;
        isDespairOn = false;
        isJoyOn = false;
        isWonderOn = false;
        isFearOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            if (i == 5)
            {
                GamePanels[i].SetActive(true);
            }
            else
            {
                GamePanels[i].SetActive(false);
            }
        }


    }

    public void DisableAll()
    {
        isPeaceOn = false;
        isRageOn = false;
        isDespairOn = false;
        isJoyOn = false;
        isWonderOn = false;
        isFearOn = false;

        runOnce = false;

        CancelInvoke();

        for (int i = 0; i < GamePanels.Length; i++)
        {
            
                GamePanels[i].SetActive(false);
            
        }
    }
}