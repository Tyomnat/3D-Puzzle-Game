using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //public GameObject player;
    public GameObject uiText;
    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponentInChildren<AudioSource>().Play();
            //Destroy(this.gameObject);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            score++;
            uiText.GetComponent<Text>().text = "Level: " + score;
        }
    }
}
