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
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }
    public void cutscenelevel1()
    {
        SceneManager.LoadScene(5);
    }
}
