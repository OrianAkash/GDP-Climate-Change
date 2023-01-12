using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    // Start is called before the first frame update
    //public Respawn die;
    public Health health;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D other)//when the player touches the collider they die immediately by using take damage function from Health.cs
    {
        /*
       if(collision.transform.tag == "Player")
        {
            die.player_Respawn();
        }
        */
       if(this.tag == "trash1")
        {
            player.transform.position = new Vector3(check1.transform.position.x, check1.transform.position.y, check1.transform.position.z);
            Debug.Log("trash 1 enter");
        }

        if (this.tag == "trash2")
        {
            player.transform.position = new Vector3(check2.transform.position.x, check2.transform.position.y, check2.transform.position.z);
        }

        if (this.tag == "trash3")
        {
            player.transform.position = new Vector3(check3.transform.position.x, check3.transform.position.y, check3.transform.position.z);
        }
        health.TakeDamage(1);
    }
}
