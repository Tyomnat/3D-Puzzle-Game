using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCube : MonoBehaviour
{
    public KeyCode key;
    public Transform destination = null;
    public GameObject player = null;
    bool taken = false;
    bool isColliding = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            taken = true;
        }
        else
        {
            taken = false;
        }

        if (this.gameObject.GetComponent<Collider>().bounds.Contains(destination.position))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    private void FixedUpdate()
    {
        if (taken && isColliding)
        {
            HoldCube();
        }
        else
        {
            ReleaseCube();
        }
    }

    private void HoldCube()
    {        
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = destination.position;
        this.transform.parent = player.transform;
    }

    private void ReleaseCube()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
    }
}
