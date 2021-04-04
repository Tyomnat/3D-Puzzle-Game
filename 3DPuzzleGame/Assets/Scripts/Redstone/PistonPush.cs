using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPush : MonoBehaviour
{
    public GameObject redstone;
    Animator animator;
    bool state = false;
    bool lastState = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        state = redstone.GetComponent<TurnOffRedstone>().GetState();
        if (state != lastState)
        {
            lastState = state;
            GetComponent<Animator>().SetBool("extend", state);
        }
    }
}
