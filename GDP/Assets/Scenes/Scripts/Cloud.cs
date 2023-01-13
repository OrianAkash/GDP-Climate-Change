using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1;
    private bool movingRight = true;
    public float xBoundary = 8;
    public GameObject rainDrops;
    public float spawnInterval = 0.1f;
    public float timeSinceLastSpawn;

    void Update()
    {
        // Move the cloud
        if (movingRight)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the cloud has reached the edge of the screen
        if (transform.position.x >= xBoundary)
        {
            movingRight = false;
        }
        else if (transform.position.x <= -xBoundary)
        {
            movingRight = true;
        }
    }
}
