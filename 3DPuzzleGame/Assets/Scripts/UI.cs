using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //public GameObject player;
    SpawnBall ballSpawn;
    bool ballsSpawned = false;
    public GameObject uiText;
    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballSpawn = FindObjectOfType(typeof(SpawnBall)) as SpawnBall;
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 1 && !ballsSpawned)
        {
            ballSpawn.SpawningBall();
            ballsSpawned = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
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
