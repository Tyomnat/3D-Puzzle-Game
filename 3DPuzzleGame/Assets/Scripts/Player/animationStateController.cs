using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    KeyCode rightMouse = KeyCode.Mouse1;

    PlayerControls player;

    Controls controls;
    Animator animator;
    int isJoggingHashForward, isJoggingHashBackward, isJoggingHashFLeft, 
        isJoggingHashFRight, isJoggingHashBLeft, isJoggingHashBRight,
        isJoggingHashLeft, isJoggingHashRight;

    int isJoggingHashFLeftSteer, isJoggingHashFRightSteer, isJoggingHashBLeftSteer,
        isJoggingHashBRightSteer, isJoggingHashLeftSteer, isJoggingHashRightSteer;

    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isJoggingHashForward = Animator.StringToHash("isJoggingForward");
        isJoggingHashFLeft = Animator.StringToHash("isJoggingForwardLeft");
        isJoggingHashFLeftSteer = Animator.StringToHash("isJoggingForwardLeftSteer");
        isJoggingHashFRight = Animator.StringToHash("isJoggingForwardRight");
        isJoggingHashFRightSteer = Animator.StringToHash("isJoggingForwardRightSteer");

        isJoggingHashBackward = Animator.StringToHash("isJoggingBackward");
        isJoggingHashBLeft = Animator.StringToHash("isJoggingBackwardLeft");
        isJoggingHashBLeftSteer = Animator.StringToHash("isJoggingBackwardLeftSteer");
        isJoggingHashBRight = Animator.StringToHash("isJoggingBackwardRight");
        isJoggingHashBRightSteer = Animator.StringToHash("isJoggingBackwardRightSteer");

        isJoggingHashLeft = Animator.StringToHash("isJoggingLeft");
        isJoggingHashLeftSteer = Animator.StringToHash("isJoggingLeftSteer");

        isJoggingHashRight = Animator.StringToHash("isJoggingRight");
        isJoggingHashRightSteer = Animator.StringToHash("isJoggingRightSteer");

        isRunningHash = Animator.StringToHash("isRunningForward");

        player = FindObjectOfType<PlayerControls>();
        controls = player.controls;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(controls.walkRun))
        {
            runMovement();
        }
        else
        {
            //remove running animation
            animator.SetBool(isRunningHash, false);
            if (Input.GetKey(rightMouse))
                mouseMovement();
            else
            {
                resetSteerBools();
                normalMovement();
            }
        }
    }

    private void resetSteerBools()
    {
        animator.SetBool(isJoggingHashFLeftSteer, false);
        animator.SetBool(isJoggingHashFRightSteer, false);
        animator.SetBool(isJoggingHashBLeftSteer, false);
        animator.SetBool(isJoggingHashBRightSteer, false);
        animator.SetBool(isJoggingHashLeftSteer, false);
        animator.SetBool(isJoggingHashRightSteer, false);
    }

    private void runMovement()
    {
        //Running
        KeyCode[] keys = { controls.forwards };
        MovementAnimation(keys, isRunningHash);
    }

    private void mouseMovement()
    {
        //Forwards Left
        KeyCode[] keys = { controls.forwards, controls.rotateLeft };
        MovementAnimation(keys, isJoggingHashFLeftSteer);
        //Forwards Right
        keys = new KeyCode[] { controls.forwards, controls.rotateRight };
        MovementAnimation(keys, isJoggingHashFRightSteer);

        //Backwards Left
        keys = new KeyCode[] { controls.backwards, controls.rotateLeft };
        MovementAnimation(keys, isJoggingHashBLeftSteer);
        //Backwards Right
        keys = new KeyCode[] { controls.backwards, controls.rotateRight };
        MovementAnimation(keys, isJoggingHashBRightSteer);

        //Strafe Left
        keys = new KeyCode[] {controls.rotateLeft };
        MovementAnimation(keys, isJoggingHashLeftSteer);
        //Strafe Right
        keys = new KeyCode[] { controls.rotateRight };
        MovementAnimation(keys, isJoggingHashRightSteer);

        normalMovement();
    }

    private void normalMovement()
    {
        //Forwards Left
        KeyCode[] keys = { controls.forwards, controls.strafeLeft };
        MovementAnimation(keys, isJoggingHashFLeft);
        //Forwards Right
        keys = new KeyCode[] { controls.forwards, controls.strafeRight };
        MovementAnimation(keys, isJoggingHashFRight);

        //Backwards Left
        keys = new KeyCode[] { controls.backwards, controls.strafeLeft };
        MovementAnimation(keys, isJoggingHashBLeft);
        //Backwards Right
        keys = new KeyCode[] { controls.backwards, controls.strafeRight };
        MovementAnimation(keys, isJoggingHashBRight);

        //Strafe Left
        keys = new KeyCode[] { controls.strafeLeft };
        MovementAnimation(keys, isJoggingHashLeft);
        //Strafe Right
        keys = new KeyCode[] { controls.strafeRight };
        MovementAnimation(keys, isJoggingHashRight);

        //Forwards
        keys = new KeyCode[] { controls.forwards };
        MovementAnimation(keys, isJoggingHashForward);
        //Backwards
        keys = new KeyCode[] { controls.backwards };
        MovementAnimation(keys, isJoggingHashBackward);
    }

    private void MovementAnimation(KeyCode[] inputs, int animationHash)
    {
        bool isMoving = animator.GetBool(animationHash);
        bool inputPressed = keysArePressed(inputs);
        if (!isMoving && inputPressed)
            animator.SetBool(animationHash, true);
        if (isMoving && !inputPressed)
            animator.SetBool(animationHash, false);
    }

    private bool keysArePressed(KeyCode[] inputs)
    {
        foreach (KeyCode input in inputs)
        {
            if (!Input.GetKey(input))
                return false;
        }
        return true;
    }
}
