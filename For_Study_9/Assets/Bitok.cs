using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitok : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.back * 70f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
