using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource walkingSound;
    bool volumeSet = false;

    bool keyPressed = false;
    bool playing = false;
    bool running = false;
    bool runningSpeed = false;
    // Start is called before the first frame update
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!volumeSet)
        {
            walkingSound.volume = walkingSound.volume / 2f;
            volumeSet = true;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            keyPressed = true;
        } 
        else
        {
            keyPressed = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }
        if (running && !runningSpeed)
        {
            walkingSound.pitch = 1.5f;
            runningSpeed = true;
        }
        else if (!running && runningSpeed)
        {
            walkingSound.pitch = 1f;
            runningSpeed = false;
        }
    }

    private void FixedUpdate()
    {       
        if (keyPressed && !playing)
        {
            walkingSound.Play();
            playing = true;
        }
        else if (!keyPressed && playing)
        {
            playing = false;
            walkingSound.Stop();
        }
    }
}
