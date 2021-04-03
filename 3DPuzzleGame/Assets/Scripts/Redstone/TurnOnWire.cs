using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWire : MonoBehaviour
{
    public GameObject lever;
    TurnOffRedstone[] offRedStoneScripts;
    bool oneTime = true;
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
            if (oneTime)
            {
                SwitchState(true);
                oneTime = false;
            }
        }
        else
        {
            if (!oneTime)
            {
                SwitchState(false);
                oneTime = true;
            }
        }
    }

    void SwitchState(bool state)
    {
        Debug.Log(state);
        foreach (var script in offRedStoneScripts)
        {
            script.state = state;
        }
    }
}
