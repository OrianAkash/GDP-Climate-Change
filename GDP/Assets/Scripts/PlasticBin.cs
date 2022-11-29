using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBin : MonoBehaviour
{
    public Movement trashtype = new Movement();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Player")
        {
            if(trashtype.inventory == "Plastic")
            {
                Debug.Log("Correct");
                trashtype.inventory = null;
            }
            else
            {
                Debug.Log("Wrong");
                trashtype.inventory = null;
            }
        }
        
    }
}