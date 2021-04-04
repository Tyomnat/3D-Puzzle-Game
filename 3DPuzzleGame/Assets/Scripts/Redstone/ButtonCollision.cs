using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public GameObject greenLamp;
    public GameObject redLamp;
    public GameObject wire;
    public GameObject cube;
    public Material greenColor;
    TurnOffRedstone[] offRedStoneScripts;

    bool updated = false;
    // Start is called before the first frame update
    void Start()
    {
        offRedStoneScripts = wire.GetComponentsInChildren<TurnOffRedstone>();
        foreach (var script in offRedStoneScripts)
        {
            script.state = false;
        }
        greenLamp.GetComponent<Renderer>().enabled = false;
        greenLamp.GetComponentInChildren<Light>().enabled = false;
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
            redLamp.GetComponent<Renderer>().enabled = false;
            redLamp.GetComponentInChildren<Light>().enabled = false;
            greenLamp.GetComponent<Renderer>().enabled = true;
            greenLamp.GetComponentInChildren<Light>().enabled = true;
            foreach (var script in offRedStoneScripts)
            {
                script.state = true;
            }
        }
    }

    public bool GetState()
    {
        return updated;
    }
}
