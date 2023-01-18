using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : MonoBehaviour
{
    public bool Interacted = false;
    public GameObject seeds;
    public GameObject btnSeed;
    public Vector3 newPosition;
    public Quaternion newRotation;
    [SerializeField] private DialougeManager dialougeManager;
    private bool triggered;

    //protected override void OnCollided(GameObject collidedObject)
    //{
    //    btnSeed.SetActive(true);
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (collidedObject.CompareTag("Player") && !triggered)
    //        {
    //            OnInteract();
    //            dialougeManager.TriggerStartDialouge();
    //            triggered = true;
    //        }
    //    }    
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        btnSeed.SetActive(true);
        if (collision.gameObject.CompareTag("Player") && !triggered)
        {
            //OnInteract();
            //dialougeManager.TriggerStartDialouge();
            //triggered = true;
        }
    }

    public void ClickFunction()
    {
        OnInteract();
        dialougeManager.TriggerStartDialouge();
        triggered = true;
        btnSeed.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        btnSeed.SetActive(false);
    }

    private void OnInteract()
    {
        if (Interacted == false)
        {
            Interacted = true;
            Debug.Log("Drop seed");
            Instantiate(seeds, newPosition, newRotation );
        }

    }

}
