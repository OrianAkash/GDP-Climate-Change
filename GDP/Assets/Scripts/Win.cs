using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winningScreen;
    public int totalObjects;
    public int objectsCollected;
    public  GameObject[] objects;

    void Start()
    {
        
        totalObjects = objects.Length;
    }

    void Update()
    {
        if (objectsCollected == totalObjects)
        {
            winningScreen.SetActive(true);
        }
    }

    public void CollectCoin()
    {
        objectsCollected++;
    }
}
