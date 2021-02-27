using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCube : MonoBehaviour
{
    public KeyCode key;
    public Transform destination = null;
    public GameObject player = null;
    bool taken = false;
    static bool isColliding = false;
    
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
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        isColliding = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {        
        isColliding = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        isColliding = true;
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
        this.transform.position = destination.position;
        this.transform.parent = player.transform;
    }

    private void ReleaseCube()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
