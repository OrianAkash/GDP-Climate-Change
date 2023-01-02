using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public List<GameObject> objectsToRemove;
    public GameObject winningScreen;
    [SerializeField] private Health health;

    void Update()
    {
        if (objectsToRemove.Count == 0 && health.currentHealth > 0)
        {
            winningScreen.SetActive(true);
        }
    }
}
