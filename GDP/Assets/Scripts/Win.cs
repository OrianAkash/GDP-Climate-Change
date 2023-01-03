using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static Win instance;
    //public List<GameObject> objectsToRemove;
    public GameObject winningScreen;
    [SerializeField] private Health health;
    public int totalCollect;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (totalCollect == 7 && health.currentHealth > 0)
        {
            winningScreen.SetActive(true);
        }
    }
    public void TotalCollect(int itemValue)
    {
        totalCollect += itemValue;
    }
}
