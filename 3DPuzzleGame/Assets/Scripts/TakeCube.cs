using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCube : MonoBehaviour
{
    Collider player = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
        if (other.gameObject.tag == "Player")
        {s
            player = other;
        }
    }

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = player.gameObject.transform.position;
        this.transform.parent = player.gameObject.transform;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
