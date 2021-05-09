using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float thrust = 10f;
    private Rigidbody rb;
    public Transform player;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*transform.LookAt(player);

        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp(distance, 10f, 20f) * thrust);*/
    }

    private void Update()
    {
        transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance >= 20)
            transform.position += transform.forward * thrust * 3 * Time.deltaTime;
        else if (distance >= 10)
            transform.position += transform.forward * thrust * 2 * Time.deltaTime;
        else
            transform.position += transform.forward * thrust * Time.deltaTime;
    }
}
