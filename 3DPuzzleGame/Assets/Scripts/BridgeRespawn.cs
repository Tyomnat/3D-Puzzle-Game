using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject == player)
        {
            Debug.Log(other.gameObject.name);
            other.transform.position = respawnPoint.position;
            //player.transform.position = respawnPoint.position;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided onCollision");
    //    if (collision.gameObject == player)
    //    {
    //        player.transform.position = respawnPoint.position;
    //    }
    //}
}
