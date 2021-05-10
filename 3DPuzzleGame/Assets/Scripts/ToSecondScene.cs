using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToSecondScene : MonoBehaviour
{
    bool respawned = false;
    public GameObject text;
    public float time = 0;

    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        text.GetComponent<Text>().text = "Time in level: " + time;
        respawned = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        StartCoroutine(CoUpdate());
    }

    IEnumerator CoUpdate()
    {
        if (respawned)
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
