using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass_broke : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
