using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerhealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;

    private void Start()
    {
        totalhealthbar.fillAmount = playerhealth.currentHealth / 4; // divide by 4 because the player will have a total of 4 hearts.When the player heart become 3 it will be 3/4 showing 3 hearts using the fillamount.
        Debug.Log(totalhealthbar.fillAmount);
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerhealth.currentHealth / 4; //divide the current health with 4 to display the number of hearts they have right now
    }
}
