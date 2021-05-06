using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public float playTime = 5.5f;
    AudioSource audio;
    public void PlaySound()
    {        
        StartCoroutine(CoUpdate());        
    }

    IEnumerator CoUpdate()
    {
        audio.Play();
        yield return new WaitForSeconds(playTime);
        audio.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
