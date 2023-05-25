using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnRate = 2f; // Time between balloon spawns
    public float spawnRadius = 5f; // Radius around the player to spawn balloons

    private float spawnTimer = 0f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnBalloon();
            spawnTimer = 0f;
        }
    }

    private void SpawnBalloon()
    {
        Vector3 randomOffset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + randomOffset;

        GameObject newBalloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
        // Optional: Customize balloon appearance or add additional components
    }
}
