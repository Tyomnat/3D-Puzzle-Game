using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRedstone : MonoBehaviour
{
    bool updated = false;
    public bool state = false;
    public Material offMaterial;
    public Material onMaterial;
    ParticleSystem ps;
    Material currentMaterial;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        UpdateState();        
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            if (!updated)
            {
                UpdateState();
                updated = true;
            }
        }
        else
        {
            if (updated)
            {
                UpdateState();
                updated = false;
            }
        }
    }

    void UpdateState()
    {
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

    public bool GetState()
    {
        return state;
    }
}
