using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorchCollision : MonoBehaviour
{
    public GameObject wire;
    public GameObject torch;
    public GameObject colliderTorch;
    bool colided = false;
    bool updated = false;
    // Start is called before the first frame update
    void Start()
    {
        var renderers = torch.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = false;
        }
        wire.GetComponent<TurnOnWire2>().state = false;
        wire.GetComponent<TurnOnWire2>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            bool col = GetComponent<Collider>().bounds.Contains(colliderTorch.transform.position);
            if (col)
            {
                colided = true;
            }
            if (colided && !updated)
            {
                updated = true;
                UpdateWireAndTorch();
                Destroy(colliderTorch);
            }
        }
        catch (Exception e)
        {

        }
    }

    void UpdateWireAndTorch()
    {
        var renderers = torch.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = true;
        }
        wire.GetComponent<TurnOnWire2>().enabled = true;
    }
}
