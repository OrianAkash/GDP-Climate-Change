using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collected : MonoBehaviour
{
    public static Collected instance;
    public TextMeshProUGUI text;
    public int collectCorrect;

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
        collectCorrect += itemValue;
        text.text = collectCorrect.ToString();
    }
    

}
