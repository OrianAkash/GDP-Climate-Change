using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : CollidableObjects
{
    public bool Interacted = false;
    public GameObject seeds;
    public Vector3 newPosition;
    public Quaternion newRotation;
    [SerializeField] private DialougeManager dialougeManager;
    private bool triggered;
    protected override void OnCollided(GameObject collidedObject)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (collidedObject.CompareTag("Player") && !triggered)
            {
                OnInteract();
                dialougeManager.TriggerStartDialouge();
                triggered = true;
            }
        }    
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
