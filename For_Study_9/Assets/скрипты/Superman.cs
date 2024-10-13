using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Superman : MonoBehaviour
{
    public float force = 10f;
    void Update()
    {
        transform.Translate(Vector3.up * 4f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody body = collision.gameObject.GetComponent<Rigidbody>();
        if (body !=null && body.CompareTag("Objectt"))
            {
            Vector3 punch_Vec = (collision.transform.position - transform.position).normalized;
            body.AddForce(punch_Vec * force, ForceMode.Impulse);
            }
    }
}