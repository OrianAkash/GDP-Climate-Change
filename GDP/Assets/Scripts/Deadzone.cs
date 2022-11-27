using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    // Start is called before the first frame update
    public Respawn die;   

    private void OnCollisionEnter2D(Collision2D collision)//when the player touches the collider they die immediately by using take damage function from Health.cs
    {
       if(collision.transform.tag == "Player")
        {
            die.player_Respawn();
        }
    }
}
