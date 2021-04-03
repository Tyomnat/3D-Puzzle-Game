using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRedstone : MonoBehaviour
{
    public bool state = false;
    public Material offMaterial;
    public Material onMaterial;
    ParticleSystem ps;
    Material currentMaterial;
    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
        ps = GetComponentInChildren<ParticleSystem>();

        if (state)
        {
            GetComponent<Renderer>().material = onMaterial;
            ps.Play();
        }
        else
        {
            GetComponent<Renderer>().material = offMaterial;
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
