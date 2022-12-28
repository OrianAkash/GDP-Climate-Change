using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestBox : MonoBehaviour
{
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.TakeDamage(1);
    }
}
