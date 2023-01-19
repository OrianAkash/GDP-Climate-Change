using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Man : MonoBehaviour
{
    public AudioSource collecteffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry2()
    {
        SceneManager.LoadScene(4);
    }

    public void ClickEffectPlay()
    {
        collecteffect.Play();
    }
    public void LevelSelect()
    {
        StartCoroutine(LoadScene());
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }
    public void cutscenelevel1()
    {
        StartCoroutine(StartScene());
        SceneManager.LoadScene(5);
    }
    public void cutscenelevel2()
    {
        SceneManager.LoadScene(6);
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
