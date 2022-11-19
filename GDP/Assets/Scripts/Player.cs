using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(5);
    }
    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.up;


        Collectable droppedItem = Instantiate(item, spawnLocation, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnLocation * .2f, ForceMode2D.Impulse);

    }
}
