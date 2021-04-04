using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWire2 : MonoBehaviour
{
    public GameObject redstoneTorch;
    public bool state = false;
    TurnOffRedstone[] offRedStoneScripts;
    bool lastState = false;
    // Start is called before the first frame update
    void Start()
    {
        offRedStoneScripts = GetComponentsInChildren<TurnOffRedstone>();
    }

    // Update is called once per frame
    void Update()
    {
        state = redstoneTorch.GetComponent<RedstoneTorch>().GetState();
        if (lastState != state)
        {
            lastState = state;
            UpdateWires();
        }
    }

    void UpdateWires()
    {
        foreach (var script in offRedStoneScripts)
        {
            script.state = state;
        }
    }
}
