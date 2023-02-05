using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 2f;
    private float timeElapsed;
    public GameObject nextButton;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)
        {
            nextButton.SetActive(true);
        }
    }
}
