using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeScript : MonoBehaviour
{
    [Header("Camera Settings")]
    public bool teleMode = false;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationY = 0F;
    public bool lockCursor = true;

    [Header("Zoom Settings")]
    public float cameraDistanceMax = 20f;
    public float cameraDistanceMin = 5f;
    public float cameraDistance = 10f;
    public float scrollSpeed = 0.5f;

    void Update()
    {
        if (teleMode)
        {
            if ((Input.GetMouseButtonDown(1)|| Input.GetKeyDown(KeyCode.Escape)))  
            {
                FindObjectOfType<ExplorationNav>().movementLock = false;
                teleMode = false;
                gameObject.SetActive(false);   
            }
            // Mouse X and Mouse Y
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }

            // Mouse scrollwheel
            cameraDistance = GetComponent<Camera>().fieldOfView;
            cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
            GetComponent<Camera>().fieldOfView = cameraDistance;

            InternalLockUpdate();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void UpdateCursorLock()
    {
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            lockCursor = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lockCursor = true;
        }

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void CheckScope()
    {
        gameObject.SetActive(true);
        teleMode = true;
        GetComponent<Camera>().fieldOfView = 40;
    }
}

