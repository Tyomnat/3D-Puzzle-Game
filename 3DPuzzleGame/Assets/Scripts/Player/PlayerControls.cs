using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Inverted gravity
    GameObject character;
    public bool scene2 = false;
    public bool invertedGravity = false;

    //Points
    public Rigidbody[] ragdollPoints;
    public Collider[] collidePoints;
    public GameObject skeleton;

    //Inputs
    public Controls controls;
    Vector2 inputs, inputNormalized;
    float rotation;
    bool run = false, jump;
    [HideInInspector]
    public bool steer;
    public KeyCode invertGravityKey = KeyCode.Space;

    //Velocity
    Vector3 velocity;
    float gravity = -12, velocityY, terminalVelocity = -25f;
    float fallMult;

    //Speed
    float currentSpeed;
    public float baseSpeed = 4, runSpeed = 2, rotateSpeed = 0.45f;

    //Ground
    Vector3 forwardDirection, collisionPoint;
    float slopeAngle, forwardAngle;
    float forwardMult;
    Ray groundRay;
    RaycastHit groundHit;

    //Jumping
    bool jumping;
    float jumpSpeed, jumpHeight = 2;
    Vector3 jumpDirection;

    CharacterController controller;
    public Transform groundDirection, fallDirection;
    [HideInInspector]
    public CameraController mainCam;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject;
        controller = GetComponent<CharacterController>();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene2)
        {
            if (Input.GetKeyDown(invertGravityKey))
            {
                invertedGravity = !invertedGravity;
                mainCam.InvertGravity();
                character.transform.eulerAngles += new Vector3(0, 0, 180);
            }
        }        
        if (ragdollPoints[0].isKinematic == true)
        {
            GetInputs();
            Locomotion();
        }
        else
        {

        }
    }

    public void DisableRagdoll()
    {
        skeleton = controller.gameObject.transform.GetChild(2).gameObject;
        ragdollPoints = skeleton.GetComponentsInChildren<Rigidbody>();
        collidePoints = skeleton.GetComponentsInChildren<Collider>();
        controller.gameObject.GetComponent<Animator>().enabled = true;
        controller.gameObject.GetComponent<CharacterController>().enabled = true;
        controller.gameObject.transform.GetChild(5).gameObject.GetComponent<Collider>().enabled = true;
        foreach (Rigidbody ragdoll in ragdollPoints)
        {
            ragdoll.isKinematic = true;
            ragdoll.detectCollisions = false;
        }

        foreach (Collider collider in collidePoints)
            collider.enabled = false;
    }

    void Locomotion()
    {
        GroundDirection();

        //Running or Walking
        if (invertedGravity || controller.isGrounded && slopeAngle <= controller.slopeLimit)
        {
            inputNormalized = inputs;
            currentSpeed = baseSpeed;

            //If SHIFT is down increase speed
            if (run)
            {
                currentSpeed *= runSpeed;

                if (inputNormalized.y < 0)
                    currentSpeed = currentSpeed / 2;
            }
        }
        else if (!controller.isGrounded || slopeAngle > controller.slopeLimit)
        {
            inputNormalized = Vector2.Lerp(inputNormalized, Vector2.zero, 0.025f);
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.025f);
        }

        //Rotating
        Vector3 characterRotation = transform.eulerAngles + new Vector3(0, rotation * rotateSpeed, 0);
        transform.eulerAngles = characterRotation;

        //If Jump key is pressed
        if (jump && controller.isGrounded && slopeAngle <= controller.slopeLimit)
            Jump();

        //Apply gravity
        if (!controller.isGrounded && velocityY > terminalVelocity)
            velocityY += gravity * Time.deltaTime;
        else if (controller.isGrounded && slopeAngle > controller.slopeLimit)
            velocityY = Mathf.Lerp(velocityY, terminalVelocity, 0.15f);

        //Applying inputs
        if (!jumping)
            velocity = (groundDirection.forward * inputNormalized.magnitude) * (currentSpeed * forwardMult) + fallDirection.up * (velocityY * fallMult);
        else
            velocity = jumpDirection * jumpSpeed + Vector3.up * velocityY;

        //Moving controller
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            //stop jumping if grounded
            if (jumping)
                jumping = false;

            //stop gravity if grounded
            velocityY = 0;
        }
    }

    void GroundDirection()
    {
        //Setting forwardDirection to controller position
        forwardDirection = transform.position;

        //Setting forwardDirection based on control input
        if (inputNormalized.magnitude > 0)
            forwardDirection += transform.forward * inputNormalized.y + transform.right * inputNormalized.x;
        else
            forwardDirection += transform.forward;

        //Setting groundDirection to look in the forwardDirection normal
        groundDirection.LookAt(forwardDirection);
        fallDirection.rotation = transform.rotation;

        forwardMult = 1;
        fallMult = 1;

        //Setting ground ray
        groundRay.origin = collisionPoint + Vector3.up * 0.05f;
        groundRay.direction = Vector3.down;

        if (Physics.Raycast(groundRay, out groundHit, 0.55f))
        {
            //Getting angles
            slopeAngle = Vector3.Angle(transform.up, groundHit.normal);
            forwardAngle = Vector3.Angle(groundDirection.forward, groundHit.normal) - 90;

            if (forwardAngle < 0 && slopeAngle <= controller.slopeLimit)
            {
                //Fixing climbing speed when climbing down slope
                forwardMult = 1 / Mathf.Cos(forwardAngle * Mathf.Deg2Rad);

                //Setting groundDirection based on forwardAngle
                groundDirection.eulerAngles += new Vector3(-forwardAngle, 0, 0);
            }
            else if (slopeAngle > controller.slopeLimit)
            {
                float groundDistance = Vector3.Distance(groundRay.origin, groundHit.point);

                if (groundDistance <= 0.1f)
                {
                    fallMult = 1 / Mathf.Cos((90 - slopeAngle) * Mathf.Deg2Rad);

                    Vector3 groundCross = Vector3.Cross(groundHit.normal, Vector3.up);
                    fallDirection.rotation = Quaternion.FromToRotation(transform.up, Vector3.Cross(groundCross, groundHit.normal));
                }
            }
        }
    }

    void Jump()
    {
        //set Jumping to true
        if (!jumping)
            jumping = true;

        //Calculate jump direction and speed
        jumpDirection = (transform.forward * inputs.y + transform.right * inputs.x).normalized;
        jumpSpeed = currentSpeed;

        if (run)
            jumpSpeed /= 1.5f;

        velocityY = Mathf.Sqrt(-gravity * jumpHeight);
    }

    void GetInputs()
    {
        //Forwards and Backwards controls
        inputs.y = Axis(Input.GetKey(controls.forwards), Input.GetKey(controls.backwards));

        //Strafe left and right
        inputs.x = Axis(Input.GetKey(controls.strafeRight), Input.GetKey(controls.strafeLeft));

        if (steer)
        {
            inputs.x += Axis(Input.GetKey(controls.rotateRight), Input.GetKey(controls.rotateLeft));

            inputs.x = Mathf.Clamp(inputs.x, -1, 1);
        }

        //Rotate left and right
        if (steer)
            rotation = Input.GetAxis("Mouse X") * mainCam.cameraSpeed;
        else
            rotation = Axis(Input.GetKey(controls.rotateRight), Input.GetKey(controls.rotateLeft));

        //Running
        if (Input.GetKey(controls.walkRun))
            run = true;
        else
            run = false;

        //Jumping
        jump = Input.GetKey(controls.jump);
    }

    public float Axis(bool pos, bool neg)
    {
        float axis = 0;

        if (pos)
            axis += 1;

        if (neg)
            axis -= 1;

        return axis;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        collisionPoint = hit.point;
    }
}