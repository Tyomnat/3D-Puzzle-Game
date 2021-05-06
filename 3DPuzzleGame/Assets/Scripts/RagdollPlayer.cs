using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPlayer : MonoBehaviour
{
    public GameObject soundEffect;
    public GameObject pendulum;
    public GameObject player;
    public Transform respawnPosition;
    GameObject skeleton;
    Rigidbody[] ragdollPoints;
    Collider[] collidePoints;
    bool collided = false;
    bool right = true;
    int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator CoUpdate()
    {
        if (collided)
        {
            soundEffect.GetComponent<SoundEffect>().PlaySound();
            yield return new WaitForSeconds(1);
            player.transform.position = respawnPosition.transform.position;
            player.GetComponent<PlayerControls>().enabled = true;            
            player.GetComponent<PlayerControls>().DisableRagdoll();
            collided = false;
            if (collisionCount == 5)
            {
                Destroy(pendulum);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CoUpdate());
        if (this.gameObject.GetComponent<Collider>().bounds.Intersects(player.transform.GetComponent<Collider>().bounds))
        {
            collisionCount++;
            collided = true;
            skeleton = player.gameObject.transform.GetChild(2).gameObject;
            ragdollPoints = skeleton.GetComponentsInChildren<Rigidbody>();
            collidePoints = skeleton.GetComponentsInChildren<Collider>();
            player.gameObject.GetComponent<PlayerControls>().enabled = false;
            player.gameObject.GetComponent<Animator>().enabled = false;
            player.gameObject.GetComponent<CharacterController>().enabled = false;
            player.gameObject.transform.GetChild(5).gameObject.GetComponent<Collider>().enabled = false;
            foreach (Rigidbody ragdoll in ragdollPoints)
            {
                ragdoll.isKinematic = false;
                ragdoll.detectCollisions = true;
            }

            foreach (Collider collider in collidePoints)
                collider.enabled = true;
        }
    }
}
