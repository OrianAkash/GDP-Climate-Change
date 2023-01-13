using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Health health;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)//when the player touches the collider they die immediately by using take damage function from Health.cs
    {
        if (other.transform.tag == "Player")
        {
            health.TakeDamage(0.5f);
        }
    }
}