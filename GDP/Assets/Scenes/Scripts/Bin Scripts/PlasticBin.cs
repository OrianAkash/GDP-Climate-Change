using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{
    public AudioSource correctThrow;
    public Health healthbar;
    public Movement trashtype = new Movement();
    public int itemValue = 1;
    [SerializeField] private DialougeManager dialougeManager;
    public bool triggered;
    public GameObject[] pestBox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Player" && trashtype.inventryfill == true)
        {
            if(trashtype.inventory == "Plastic")
            {
                correctThrow.Play();
                Debug.Log("Correct");
                trashtype.inventory = null;
                trashtype.inventext.text = null;
                trashtype.inventryfill = false;
                Collected.instance.ChangeCollect(itemValue);
                Win.instance.TotalCollect(itemValue);
                if (triggered == false)
                {
                    dialougeManager.TriggerStartDialouge();
                    triggered = true;
                }
            }
            else
            {
                Debug.Log("Wrong");
                trashtype.inventory = null;
                trashtype.inventext.text = null;
                trashtype.inventryfill = false;
                healthbar.TakeDamage(1);
                Win.instance.TotalCollect(itemValue);
                pestBox[Random.Range(0, pestBox.Length)].SetActive(true);
            }
        }       
    }
}