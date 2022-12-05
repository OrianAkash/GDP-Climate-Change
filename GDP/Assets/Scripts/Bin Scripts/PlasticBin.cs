using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{
    public Health healthbar;
    public Movement trashtype = new Movement();
    public int itemValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Player" && trashtype.inventryfill == true)
        {
            if(trashtype.inventory == "Plastic")
            {
                Debug.Log("Correct");
                trashtype.inventory = null;
                trashtype.inventext.text = null;
                trashtype.inventryfill = false;
                Collected.instance.ChangeCollect(itemValue);
            }
            else
            {
                Debug.Log("Wrong");
                trashtype.inventory = null;
                trashtype.inventext.text = null;
                trashtype.inventryfill = false;
                healthbar.TakeDamage(1);
            }
        }       
    }
}