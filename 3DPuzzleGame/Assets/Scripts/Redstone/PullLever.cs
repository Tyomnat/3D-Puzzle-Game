using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    Animator animator;
    bool isPulled = false;

    public KeyCode key;
    public Transform playerTouch = null;
    public GameObject leverCollider = null;
    bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leverCollider.GetComponent<Collider>().bounds.Contains(playerTouch.position))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }

        if (Input.GetKeyDown(key) && isColliding)
        {
            ChangeLeverState();
        }
    }

    void ChangeLeverState()
    {
        isPulled = !isPulled;
        animator.SetBool("open", isPulled);
    }
}
