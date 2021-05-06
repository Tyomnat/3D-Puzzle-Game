using UnityEngine;

public class sledMovement : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;

    public float moveSpeed = 0.01f;
    public float gravity = 9.8f;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.y -= gravity * Time.deltaTime;
        moveVector.z = Input.GetAxis("Vertical") * moveSpeed;

        characterController.Move(moveVector * Time.deltaTime);
    }
}
