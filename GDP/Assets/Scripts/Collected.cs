using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collected : MonoBehaviour
{
    public static Collected instance;
    public TextMeshProUGUI text;
    int collect;
    public int NumberOfRubbishInTheScene;
    public GameObject winningScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCollect(int itemValue)
    {
        collect += itemValue;
        text.text = collect.ToString();
    }

    void Update()
    {
        if (text.text == NumberOfRubbishInTheScene.ToString())
        {
            winningScreen.SetActive(true);
        }
    }
}
