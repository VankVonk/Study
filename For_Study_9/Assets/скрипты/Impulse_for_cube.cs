using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse_for_cube : MonoBehaviour
{

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * 10f, ForceMode.Impulse);
    }

}    
