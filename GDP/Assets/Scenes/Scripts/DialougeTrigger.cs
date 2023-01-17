using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private DialougeManager dialougeManager;
    public Movement inventfill;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inventfill.inventryfill == true && other.CompareTag("Player") && triggered == false )
        {
            triggered = true;
            dialougeManager.TriggerStartDialouge();
        }
    }
}
