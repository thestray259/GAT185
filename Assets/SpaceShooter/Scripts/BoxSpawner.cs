using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] float minTime; 
    [SerializeField] float maxTime;
    [SerializeField] bool active = false; 

    BoxCollider boxCollider = null;
    float timer; 

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        timer = Random.Range(minTime, maxTime);
        GameManager.Instance.startGameEvent += OnStartGame; 
    }

    void Update()
    {
        if (!active) return; 

        timer -= Time.deltaTime; 
        if (timer <= 0)
        {
            timer = Random.Range(minTime, maxTime);

            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], GetRandomPointInBoxCollider(), transform.rotation);
        }
    }

    public void OnStartGame()
    {
        active = true; 
    }

    Vector3 GetRandomPointInBoxCollider()
    {
        Vector3 point = Vector3.zero;

        Vector3 min = boxCollider.bounds.min; 
        Vector3 max = boxCollider.bounds.max;

        point.x = Random.Range(min.x, max.x); 
        point.y = Random.Range(min.y, max.y); 
        point.z = Random.Range(min.z, max.z); 

        return point; 
    }
}
