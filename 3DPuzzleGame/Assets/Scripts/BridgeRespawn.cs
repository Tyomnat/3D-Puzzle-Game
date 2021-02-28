using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    bool respawned = false;
    GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CoUpdate());
    }

    IEnumerator CoUpdate()
    {
        if (respawned)
        {
            yield return new WaitForSeconds(1);
            player.GetComponent<PlayerControls>().enabled = true;
            respawned = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            Debug.Log(other.gameObject.name);
            other.GetComponent<PlayerControls>().enabled = false;
            other.transform.position = respawnPoint.position;            
            respawned = true;
        }
    }
}
