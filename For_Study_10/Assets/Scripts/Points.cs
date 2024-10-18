using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int points = 0;
    public Text Score;
    private void Update()
    {
        Score.text = points + " очков";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("10"))
        {
            points += 10;
        }
        else if(collision.gameObject.CompareTag("20"))
        {
            points += 20;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("reset"))
        {
            points = 0;
        }
    }
}
