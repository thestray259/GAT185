using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWeapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] float fireRate;

    float fireTimer = 0;

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && fireTimer <= 0))
        {
            fireTimer -= Time.deltaTime;
            //Fire();
        }
    }

    public void Fire()
    {
        if (fireTimer <= 0)
        {
            fireTimer = fireRate; 
            Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
