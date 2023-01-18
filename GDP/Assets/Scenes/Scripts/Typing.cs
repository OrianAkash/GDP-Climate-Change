using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Typing : MonoBehaviour
{
    public float textSpeed;
    public string[] lines;
    public TextMeshProUGUI textComponent;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        Type();
    }
    void StartType()
    {
        index = 0;
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
