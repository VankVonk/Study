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

    private bool isPull = true; // натянуто или нет 
    private Vector3 initialPos;
    private Vector3 pullPos;
    private Rigidbody rb;
   
    void Start()
    {
        initialPos = transform.position;
        pullPos = initialPos - new Vector3(0, 0, pullDistance);
        rb = GetComponent<Rigidbody>();
        rb.MovePosition(pullPos);
    }
    void Update()
    {
        if (isPull)
        {
            rb.MovePosition(pullPos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            releaseSpring();
        }
        else
        {
            isPull = true;
        }
    }
    void releaseSpring()
    {
        isPull = false;
        rb.AddForce(Vector3.forward * releaseForce, ForceMode.Impulse);
    }
}
