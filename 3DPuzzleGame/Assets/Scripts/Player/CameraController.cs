using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool cameraChange = false;

    //Input Variables
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1;

    //Camera Variables
    public float cameraHeight = 1.25f, cameraMaxDistance = 5;
    float cameraMaxTilt = 90;
    [Range(0, 4)]
    public float cameraSpeed = 2;
    float currentPan, currentTilt = 20, currentDistance = 3;

    //CamState
    public CameraState cameraState = CameraState.CameraNone;

    //References
    PlayerControls player;
    public Transform tilt;
    Camera mainCam;

    void Start()
    {
        player = FindObjectOfType<PlayerControls>();
        if (player.name == "Player")
            cameraSetup(player);
    }

    void cameraSetup(PlayerControls player)
    {
        player.mainCam = this;
        mainCam = Camera.main;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCam.transform.position += tilt.forward * -currentDistance;
    }

    void Update()
    {
        if (cameraChange)
        {
            Debug.Log("WE HERE1");
            PlayerControls[] players = FindObjectsOfType<PlayerControls>();
            foreach (PlayerControls pc in players)
            {
                Debug.Log("WE HERE2");
                if (pc.gameObject.name == "PlayerInSled")
                {
                    Debug.Log("WE HERE3");
                    player = pc;
                    cameraSetup(player);
                    break;
                }
            }
        }
        if (!Input.GetKey(leftMouse) && !Input.GetKey(rightMouse)) // if no mouse button is pressed
            cameraState = CameraState.CameraNone;
        else if (Input.GetKey(leftMouse) && !Input.GetKey(rightMouse)) // if left mouse button is pressed
            cameraState = CameraState.CameraRotate;
        else if (!Input.GetKey(leftMouse) && Input.GetKey(rightMouse)) // if right mouse button is pressed
            cameraState = CameraState.CameraSteer;

        CameraInputs();
    }

    void LateUpdate()
    {
        cameraTransforms();
    }

    void CameraInputs()
    {
        if (cameraState != CameraState.CameraNone)
        {
            if (cameraState == CameraState.CameraRotate)
            {
                if (player.steer)
                    player.steer = false;
                currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
            }
            else if (cameraState == CameraState.CameraSteer)
            {
                if (!player.steer)
                    player.steer = true;
            }

            currentTilt -= Input.GetAxis("Mouse Y")* cameraSpeed;
            currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt);
        }
        else
        {
            if (player.steer)
                player.steer = false;
        }

        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * 2;
        currentDistance = Mathf.Clamp(currentDistance, 1, cameraMaxDistance);
    }

    void cameraTransforms()
    {
        switch (cameraState)
        {
            case CameraState.CameraSteer:
            case CameraState.CameraNone:
                currentPan = player.transform.eulerAngles.y;
                break;
        }

        if (cameraState == CameraState.CameraNone)
            currentTilt = 20;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCam.transform.position = transform.position + tilt.forward * -currentDistance;
    }

    public enum CameraState { CameraNone, CameraRotate, CameraSteer }
}
