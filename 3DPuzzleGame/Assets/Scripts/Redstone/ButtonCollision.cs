using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public GameObject cube;
    public Material greenColor;

    bool updated = false;
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
        if (!updated)
        {
            updated = true;
            GetComponent<Renderer>().material = greenColor;
        }
    }

    public bool GetState()
    {
        return updated;
    }
}
