using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyAudio : MonoBehaviour
{
    public GameObject effectsSlider = null;
    float volume = 1f;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (effectsSlider != null)
        {
            if (this.name == "EffectsSoundVolume")
            {
                volume = effectsSlider.GetComponent<Slider>().value;
            }
        }
    }

    public float GetEffectsVolume()
    {
        return volume;
    }
}
