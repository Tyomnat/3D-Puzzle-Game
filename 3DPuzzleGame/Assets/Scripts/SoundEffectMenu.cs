using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject volumeObject = GameObject.Find("EffectsSoundVolume");
        if (volumeObject != null)
        {
            SetVolumes(volumeObject.GetComponent<DontDestroyAudio>().GetEffectsVolume());
        } 
        else
        {
            SetVolumes(1f);
        }        
    }

    void SetVolumes(float volume)
    {
        GameObject[] coinSounds = GameObject.FindGameObjectsWithTag("PartySound");
        AudioSource[] audiosources = GetComponentsInChildren<AudioSource>();
        foreach (var audiosource in audiosources)
        {
            audiosource.volume = volume;
        }
        foreach (var coinSound in coinSounds)
        {
            coinSound.GetComponent<AudioSource>().volume = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
