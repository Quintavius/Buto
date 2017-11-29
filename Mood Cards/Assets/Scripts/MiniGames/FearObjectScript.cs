using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearObjectScript : MonoBehaviour {

    private float fallSpeed;
    private Vector3 randRot;
    private Vector3 temp;
    private float randNum;

    MiniGameScript miniGameScript;

    // Use this for initialization
    void Start () {
        miniGameScript = FindObjectOfType<MiniGameScript>();

        fallSpeed = Random.Range((200f * (Screen.height / 412)), (300f * (Screen.height / 412)));
  
        if (transform.parent.name == "Top")
        {
            randNum = Random.Range(-60f, 60f);
            randRot = new Vector3(0, 0, randNum);
            transform.Rotate(randRot);

            temp = (Quaternion.Euler(0, 0, randNum) * Vector3.down);
        }

        else if (transform.parent.name == "Right")
        {
            randNum = Random.Range(-60f, 60f);
            randRot = new Vector3(0, 0, randNum);
            transform.Rotate(randRot);

            temp = (Quaternion.Euler(0, 0, randNum) * Vector3.left);
        }

        else if (transform.parent.name == "Bottom")
        {
            randNum = Random.Range(-60f, 60f);
            randRot = new Vector3(0, 0, randNum);
            transform.Rotate(randRot);

            temp = (Quaternion.Euler(0, 0, randNum) * Vector3.up);
        }

        else if (transform.parent.name == "Left")
        {
            randNum = Random.Range(-60f, 60f);
            randRot = new Vector3(0, 0, randNum);
            transform.Rotate(randRot);

            temp = (Quaternion.Euler(0, 0, randNum) * Vector3.right);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.parent.name == "Top")
        {
            transform.Translate(temp * fallSpeed * Time.deltaTime, Space.World);
         }

        else if (transform.parent.name == "Right")
        {
            transform.Translate(temp * fallSpeed * Time.deltaTime, Space.World);
        }

        else if (transform.parent.name == "Bottom")
        {
            transform.Translate(temp * fallSpeed * Time.deltaTime, Space.World);
        }

        else if (transform.parent.name == "Left")
        {
            transform.Translate(temp * fallSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FearBlock")
        {
            Destroy(gameObject);
            miniGameScript.playerLives -= 1;

            if (miniGameScript.playerLives <= 0)
            {
                Debug.Log("Player died, restarting");
                miniGameScript.DisableAll();
                miniGameScript.EnableFear();
            }
        }
        else if (collision.transform.parent.name == "FearBorder")
        {
            Destroy(gameObject);
        }
    }


}
