using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{
    public GameObject deathsound;
    static Vector3 respawnPoint;
    bool respawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag=="LevelCount")
        {
            //Debug.Log("Respawn set");
            respawnPoint = collision.gameObject.transform.position;
        }
        if (collision.gameObject.tag=="Water")
        {
            deathsound.GetComponent<SoundEffect>().PlaySound();
            GetComponentInParent<PlayerControls>().enabled = false;
            //Debug.Log("water");
            this.transform.position = respawnPoint;
            respawned = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = this.transform.position;        
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
            GetComponent<PlayerControls>().enabled = true;
            //Debug.Log("enabled");
            respawned = false;
        }
    }
}
