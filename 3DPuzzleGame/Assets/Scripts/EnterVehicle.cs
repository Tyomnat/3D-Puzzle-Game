using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    public GameObject guiObj;
    GameObject player;
    GameObject inactiveSled;
    GameObject activeSled;

    public GameObject walkingSound;
    bool walkingSoundOn = true;


    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
        inactiveSled = gameObject.transform.GetChild(0).gameObject;
        activeSled = gameObject.transform.GetChild(1).gameObject;
        activeSled.SetActive(false);
        inactiveSled.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                guiObj.SetActive(false);
                activeSled.SetActive(true);
                inactiveSled.SetActive(false);
                //player.transform.parent = gameObject.transform;
                //vehicleScript.enabled = true;
                //player.SetActive(false);
                //inVehicle = true;
                other.gameObject.SetActive(false);
                other.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
            }
            if (walkingSoundOn)
            {
                walkingSound.GetComponent<WalkingSound>().enabled = false;
                walkingSound.GetComponent<AudioSource>().Stop();
                walkingSoundOn = false;
            }
        }
        else if (!walkingSound)
        {
            walkingSound.GetComponent<WalkingSound>().enabled = true;
            walkingSoundOn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}
