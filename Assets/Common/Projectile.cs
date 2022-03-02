using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;

    public void Start()
	{
        Vector3 force = transform.rotation * (Vector3.forward * speed);
        rb.AddForce(force); 

        rb.AddRelativeForce(Vector3.forward * speed, forceMode);
	}
}
