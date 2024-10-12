using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaBOOM : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 3f;


    private void FixedUpdate()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            }
        }
    }
}

