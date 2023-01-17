using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantArea : MonoBehaviour
{
    public Movement movement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (movement.inventryfill == true && other.CompareTag("Player"))
        {
            movement.inventryfill = false;
        }
    }
}
