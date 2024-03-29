using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public AudioSource damage;
    [SerializeField] private float startingHealth;
    public float currentHealth;
    public GameObject cameraTag;
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
            damage.Play();
        }
        else if(currentHealth <=0)
        {
            if(cameraTag.tag == "level 1")
            {
                SceneManager.LoadScene(2);
            }
            else if (cameraTag.tag == "level2")
            {
                SceneManager.LoadScene(4);
            }
            
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
