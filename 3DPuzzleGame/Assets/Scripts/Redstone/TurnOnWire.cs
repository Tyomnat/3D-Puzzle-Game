using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWire : MonoBehaviour
{
    public GameObject lever;
    TurnOffRedstone[] offRedStoneScripts;
    bool updated = true;
    // Start is called before the first frame update
    void Start()
    {
        offRedStoneScripts = GetComponentsInChildren<TurnOffRedstone>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lever.GetComponent<PullLever>().IsPulled());
        if (lever.GetComponent<PullLever>().IsPulled())
        {
            if (updated)
            {
                SwitchState(true);
                updated = false;
            }
        }
        else
        {
            if (!updated)
            {
                SwitchState(false);
                updated = true;
            }
        }
    }

    void SwitchState(bool state)
    {
        foreach (var script in offRedStoneScripts)
        {
            script.state = state;
        }
    }
}
