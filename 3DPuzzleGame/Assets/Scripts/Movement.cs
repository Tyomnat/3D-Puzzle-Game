using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float moveSpeed = 0.2f;
    public float rotationSpeed = 2.5f;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(vertical, 0.0f, 0);

        transform.Translate(movement * moveSpeed);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + horizontal * rotationSpeed, 0);
    }
}
