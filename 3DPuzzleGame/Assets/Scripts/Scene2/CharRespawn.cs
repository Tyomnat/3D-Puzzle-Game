using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRespawn : MonoBehaviour
{
    GameObject character;
    public Transform respawnPoint;
    bool respawned = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            GetComponentInParent<PlayerControls>().enabled = false;
            this.transform.position = respawnPoint.position;
            if (GetComponent<PlayerControls>().invertedGravity)
            {
                GetComponent<PlayerControls>().invertedGravity = false;
                character.GetComponentInChildren<CameraController>().InvertGravity();
                transform.parent.gameObject.transform.eulerAngles += new Vector3(0, 0, -180);
            }            
            respawned = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject;
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
            respawned = false;
        }
    }
}
