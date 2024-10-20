using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_loose : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            Points.points = 0;
        }
    }
}
