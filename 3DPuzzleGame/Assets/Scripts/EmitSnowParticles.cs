using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSnowParticles : MonoBehaviour
{
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!particleSystem.isPlaying && collision.gameObject.tag=="Snow")
            particleSystem.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (particleSystem.isPlaying)
            particleSystem.Stop();
    }
}
