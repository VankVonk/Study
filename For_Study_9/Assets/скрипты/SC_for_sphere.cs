using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SC_for_sphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.useGravity = false;
    }
    private void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.useGravity = true;
    }
}
