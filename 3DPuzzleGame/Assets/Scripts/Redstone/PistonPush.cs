using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPush : MonoBehaviour
{
    public GameObject soundEffect;
    public GameObject redstone;
    Animator animator;
    bool state = false;
    bool lastState = false;

    bool used = false;
    bool played = false;
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
            used = true;
        }        
    }

    private void FixedUpdate()
    {
        if (used && !played)
        {
            played = true;
            soundEffect.GetComponent<SoundEffect>().PlaySound();
        }
    }
}
