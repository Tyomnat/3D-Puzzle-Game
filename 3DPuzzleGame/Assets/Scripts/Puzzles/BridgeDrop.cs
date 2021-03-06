﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDrop : MonoBehaviour
{
    [SerializeField]
    GameObject soundEffect;
    [SerializeField]
    GameObject box;
    [SerializeField]
    GameObject holder1;
    [SerializeField]
    GameObject holder2;
    [SerializeField]
    GameObject redCylinder;
    [SerializeField]
    GameObject greenCylinder;
    [SerializeField]
    GameObject fallingBridge;

    int fallCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        redCylinder.GetComponent<Renderer>().enabled = true;
        greenCylinder.GetComponent<Renderer>().enabled = false;
        fallingBridge.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            fallCount++;
            if (fallCount < 2)
            {
                soundEffect.GetComponent<AudioSource>().Play();
            }            
            redCylinder.GetComponent<Renderer>().enabled = false;
            greenCylinder.GetComponent<Renderer>().enabled = true;
            fallingBridge.GetComponent<Renderer>().enabled = true;
            Destroy(holder1);
            Destroy(holder2);
        }
    }
}
