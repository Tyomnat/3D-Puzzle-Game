using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDrop : MonoBehaviour
{
    [SerializeField]
    GameObject box;
    [SerializeField]
    GameObject holder1;
    [SerializeField]
    GameObject holder2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            Destroy(holder1);
            Destroy(holder2);
        }
    }
}
