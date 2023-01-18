using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float patrolSpeed = 1.0f;
    public float chaseSpeed = 3.0f;
    public float chaseRadius = 5.0f;
    public GameObject player;

    private bool isPatrolling = true;
    private bool isGoingToA = true;

    void Update()
    {
        if (isPatrolling)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }

    void Patrol()
    {
        if (isGoingToA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, patrolSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointA.transform.position) < 0.1f)
            {
                isGoingToA = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.transform.position, patrolSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointB.transform.position) < 0.1f)
            {
                isGoingToA = true;
            }
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector2.Distance(transform.position, other.transform.position) < chaseRadius)
            {
                isPatrolling = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPatrolling = true;
        }
    }
}