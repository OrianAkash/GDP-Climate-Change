using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantArea : MonoBehaviour
{
    public GameObject tree;
    public Movement movement;
    public int itemValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        tree.SetActive(true);
        if (movement.inventryfill == true && other.CompareTag("Player"))
        {
            Collected.instance.ChangeCollect(itemValue);
            Win.instance.TotalCollect(itemValue);
            movement.inventryfill = false;
        }
    }
}
