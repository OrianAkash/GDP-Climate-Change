using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage (float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth >0)
        {

        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        */
    }
}
