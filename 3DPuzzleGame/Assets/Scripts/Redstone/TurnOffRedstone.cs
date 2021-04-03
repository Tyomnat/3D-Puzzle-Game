using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRedstone : MonoBehaviour
{
    public bool defaultState = false;
    public Material offMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if (!defaultState)
        {
            GetComponent<Renderer>().material = offMaterial;
            var ps = GetComponentInChildren<ParticleSystem>();
            ps.Stop();
        }             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
