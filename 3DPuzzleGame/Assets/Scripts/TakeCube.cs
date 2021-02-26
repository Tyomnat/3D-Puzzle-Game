using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCube : MonoBehaviour
{
    public KeyCode key;
    Collider player = null;
    bool taken = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && player != null)
        {
            if (taken)
            {
                ReleaseCube();
            } 
            else
            {
                HoldCube();
            }
            taken = !taken;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
        if (other.gameObject.tag == "Player")
        {
            player = other;
        }
        HoldCube();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        
    }

    void HoldCube()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = player.gameObject.transform.position;
        this.transform.parent = player.gameObject.transform;
    }

    void ReleaseCube()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
