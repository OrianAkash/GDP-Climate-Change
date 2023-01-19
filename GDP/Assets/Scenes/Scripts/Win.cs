using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win : MonoBehaviour
{
    public AudioSource theme;
    public AudioSource wingame;
    public AudioSource correctanswersound;
    public AudioSource wronganswersound;
    public static Win instance;
    //public List<GameObject> objectsToRemove;
    public GameObject winningScreen;
    public GameObject correctScreen;
    public GameObject wrongScreen;
    [SerializeField] private Health health;
    public int totalCollect;
    public Collected collect;
    public TextMeshProUGUI displayScore;
    public TextMeshProUGUI correctScore;
    public TextMeshProUGUI wrongScore;
    public GameObject Left;
    public GameObject Right;
    public GameObject Jump;
    public GameObject camera;
    public GameObject dash;
    public GameObject back;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (camera.tag == "level 1")
        {
            if (totalCollect == 7 && health.currentHealth > 0 )
            {
                theme.Stop();
                //wingame.Play();
                winningScreen.SetActive(true);
                Jump.SetActive(false);
                Right.SetActive(false);
                Left.SetActive(false);
                back.SetActive(false);
            }
        }
        else if (camera.tag == "level2")
        {
            if (totalCollect == 3 && health.currentHealth > 0)
            {
                theme.Stop();
                //wingame.Play();
                winningScreen.SetActive(true);
                Jump.SetActive(false);
                Right.SetActive(false);
                Left.SetActive(false);
                dash.SetActive(false);
                back.SetActive(false);
            }
        }

        displayScore.text = "Score "+ (collect.collectCorrect*15);
    }
    public void TotalCollect(int itemValue)
    {
        totalCollect += itemValue;
    }

    public void CorrectAnswer()
    {
        correctanswersound.Play();
        winningScreen.SetActive(false);
        correctScore.text = "Score "+(collect.collectCorrect * 15) * 2;
        correctScreen.SetActive(true);
    }

    public void WrongAnswer()
    {
        wronganswersound.Play();
        winningScreen.SetActive(false);
        wrongScore.text = "Score " + (collect.collectCorrect*15);
        wrongScreen.SetActive(true);
    }


}
