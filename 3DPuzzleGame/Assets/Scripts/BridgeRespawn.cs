using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRespawn : MonoBehaviour
{
    public GameObject respawnPoint;
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
        if (other.gameObject == player)
        {
            player.gameObject.transform.position = respawnPoint.gameObject.transform.position;
        }
    }
}
