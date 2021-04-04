using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedstoneTorch : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;
    public GameObject wire = null;
    public bool torchState = true;
    bool lastState = true;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wire != null)
        {
            torchState = !wire.GetComponent<TurnOffRedstone>().GetState();
        }
        if (lastState != torchState)
        {
            lastState = torchState;
            UpdateState();
        }
    }

    void UpdateState()
    {
        if (torchState)
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
        return torchState;
    }
}
