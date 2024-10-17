using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public SpringJoint springJoint;
    public float pullForce = 10f;
    public float releaseForce = 50f;
    public float pullDistance = 2f;
    public float releaseDistace = 0.5f;

    private bool isPull = false;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
        pullSpring();
    }
    void Update()
    {
        if (isPull = true)
        {
                release_spring(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            pullSpring();
            Debug.Log("Ўарик коснулс€");
        }
    }

    void pullSpring()// нат€гивание
    {
        transform.position = initialPos - Vector3.up * pullDistance;
        isPull = true;
    }

    void release_spring() //вытолк
    {
        transform.position = initialPos;
        isPull = false;
    }
    
}
