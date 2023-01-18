using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 2f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(0);
        }
    }
}
