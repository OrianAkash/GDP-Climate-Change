using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestBox : MonoBehaviour
{
    public Health playerHealth;
    public Movement dash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (dash.isDashing == true)
            {

            }
            else
            {
                playerHealth.TakeDamage(0.5f);
            }
        }
                
    }
}
