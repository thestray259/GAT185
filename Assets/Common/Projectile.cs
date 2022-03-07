using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;
    [SerializeField] float timer; 

    [SerializeField] GameObject destroyPrefab; 

    public void Start()
	{
/*        Vector3 force = transform.rotation * (Vector3.forward * speed);
        rb.AddForce(force); */

        rb.AddRelativeForce(Vector3.forward * speed, forceMode);
        if (timer != 0) StartCoroutine(DestroyTime()); 
	}

    IEnumerator DestroyTime()
    {
        //Time.timeScale = 2; 
        //Time.unscaledDeltaTime
        yield return new WaitForSeconds(timer);

        if (destroyPrefab != null) Instantiate(destroyPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyPrefab != null) Instantiate(destroyPrefab, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
