using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bitok : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.back * 70f, ForceMode.Impulse);
    }
}