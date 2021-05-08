using UnityEngine;

public class sledMovement : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;

    public float moveSpeed = 0.01f;
    public float gravity = 9.8f;

    private int rotationSpeed = 5;
    public bool grounded;
    private Vector3 posCur;
    private Quaternion rotCur;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAlignment();
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.y -= gravity * Time.deltaTime;
        moveVector.z = Input.GetAxis("Vertical") * moveSpeed;
        characterController.Move(moveVector * Time.deltaTime);
    }

    void GetAlignment()
    {
        //declare a new Ray. It will start at this object's position and it's direction will be straight down from the object (in local space, that is)
        Ray ray = new Ray(transform.position, -transform.up);
        //decalre a RaycastHit. This is neccessary so it can get "filled" with information when casting the ray below.
        RaycastHit hit;
        //cast the ray. Note the "out hit" which makes the Raycast "fill" the hit variable with information. The maximum distance the ray will go is 1.5
        if (Physics.Raycast(ray, out hit, 1.5f) == true)
        {
            //draw a Debug Line so we can see the ray in the scene view. Good to check if it actually does what we want. Make sure that it uses the same values as the actual Raycast. In this case, it starts at the same position, but only goes up to the point that we hit.
            Debug.DrawLine(transform.position, hit.point, Color.green);
            //store the roation and position as they would be aligned on the surface
            rotCur = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            posCur = new Vector3(transform.position.x, hit.point.y, transform.position.z);

            grounded = true;

        }
        //if you raycast didn't hit anything, we are in the air and not grounded.
        else
        {
            grounded = false;
        }


        if (grounded == true)
        {
            //smoothly rotate and move the objects until it's aligned to the surface. The "5" multiplier controls how fast the changes occur and could be made into a seperate exposed variable
            transform.position = Vector3.Lerp(transform.position, posCur, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, Time.deltaTime * rotationSpeed);
        }
        else
        {
            //if we are not grounded, make the object go straight down in world space (simulating gravity). the "1f" multiplier controls how fast we descend.
            transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.up * 1f, Time.deltaTime * rotationSpeed);
            //if we are not grounded, make the vehicle's rotation "even out". Not completey reaslistic, but easy to work with.
            rotCur.eulerAngles = Vector3.zero;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, Time.deltaTime);
        }
    }
}
