using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    //player walk into collectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>(); //check if collider which enters the collectables trigger is the player

        if (player)
        {
            player.inventory.Add(this); //add the number of collectables to the player
            Destroy(this.gameObject); //remove the collectables from the scene once collected
        }
    }
}
public enum CollectableType
{
    NONE, TREE_SEEDS
}
