using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_for_red : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Points.points += 20;
        }
    }
}
