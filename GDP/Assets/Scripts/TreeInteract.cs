using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : CollidableObjects
{
    private bool Interacted = false;
    public GameObject seeds;
    public Vector3 newPosition;
    public Quaternion newRotation;
    [SerializeField] private DialougeManager dialougeManager;
    private bool triggered;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
            if (collidedObject.CompareTag("Player") && !triggered)
            {
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
