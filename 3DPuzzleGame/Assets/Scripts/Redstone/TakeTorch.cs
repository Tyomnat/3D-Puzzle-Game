using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTorch : MonoBehaviour
{
    public KeyCode key = KeyCode.F;

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
            HoldTorch();
        }
        else
        {
            ReleaseTorch();
        }
    }

    private void HoldTorch()
    {
        this.transform.position = destination.position;
        this.transform.parent = player.transform;
    }

    private void ReleaseTorch()
    {
        this.transform.parent = null;
    }
}
