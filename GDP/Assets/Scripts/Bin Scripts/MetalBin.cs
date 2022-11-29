using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBin : MonoBehaviour
{
    public Movement trashtype = new Movement();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && trashtype.inventryfill == true)
        {
            if (trashtype.inventory == "Metal")
            {
                Debug.Log("Correct");
                trashtype.inventory = null;
                trashtype.inventryfill = false;
            }
            else
            {
                Debug.Log("Wrong");
                trashtype.inventory = null;
                trashtype.inventryfill = false;
            }
        }
    }
}
