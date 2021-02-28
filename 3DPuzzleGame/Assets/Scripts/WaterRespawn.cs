using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{
    static Vector3 respawnPoint;
    

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag=="LevelCount")
        {
            Debug.Log("Respawn set");
            respawnPoint = collision.gameObject.transform.position;
        }   
        if (collision.gameObject.tag=="Water")
        {
            GetComponent<PlayerControls>().enabled = false;
            Debug.Log("water");
            Debug.Log(this.transform.position.ToString() + " " + respawnPoint.ToString());
            this.transform.position = respawnPoint;
            //GetComponent<PlayerControls>().enabled = true;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on enter");
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = this.transform.position;
    }    

    // Update is called once per frame
    void Update()
    {

    }
}
