using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_for_green : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Points.points += 10;
        }
    }
}
