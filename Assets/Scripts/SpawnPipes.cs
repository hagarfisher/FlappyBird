using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1.4f;

    private void OnEnable()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    private void onDisable()
    {
        CancelInvoke("Spawn");
    }

    private void Spawn()
    {
        float height = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(transform.position.x, height, 0f);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

}
