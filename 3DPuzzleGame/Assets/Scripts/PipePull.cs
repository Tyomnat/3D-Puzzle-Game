using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePull : MonoBehaviour
{
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
        if (other.tag == "Player")
        {            
            other.transform.position = this.transform.position;
            other.GetComponent<PlayerControls>().enabled = false;
        }
    }
}
