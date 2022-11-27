using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform currentCheckpoint; // Store the last checkpoint
    //public GameObject respawn_particles;
    //public Timer time;
    //int score;

    void Awake()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            player_Respawn();
        }
    }

    public void player_Respawn()
    {
        //transform.position = currentCheckpoint.position; //Move the player to the position of the checkpoint
        transform.position = new Vector3(currentCheckpoint.position.x, 0, transform.position.z); //spawns at the checkpoint location but the y=0
        //Restore player health
        //GetComponent<Movement>().enabled = true; //disabling player movement script so the player cannot move after they die
    }

    //Activate Checkpoint
    private void OnTriggerEnter2D(Collider2D collision) //when the player enters the checkpoint
    {
        if (collision.transform.tag == "StartTimer" || collision.transform.tag == "StopTimer")
        {
            currentCheckpoint = collision.transform; //Store the checkpoint that we activated as the current one
            collision.GetComponent<Collider2D>().enabled = false;// Deactivate Collider
        }
        /*
        if (collision.transform.tag == "StartTimer") //if the tag of the checkpoint is StartTimer
        {
            time.BeginTimer(); //starts the timer from Timer.cs
        }
        else if (collision.transform.tag == "StopTimer") //if the tag is StopTimer
        {
            time.EndTimer(); //Ends the timer
            int seconds = (int)Mathf.Floor(time.elapsedTime); //converts milliseconds into seconds by flooring it into a seconds value then convert into integer using (int)
            Debug.Log(seconds);
            CalculateScore(seconds); //calls the calculatescore function and passes through the seconds took
        }

    }

    public void CalculateScore(int s)
    {
        score = (1000 + (kill.kill_count * 100)) / (s); //calculate score by multiplying the number of enemy kill by 100 and add 1000 then divide the answer with seconds the player took to reach the end checkpoint
        Debug.Log(kill.kill_count);
        GameObject text_score = GameObject.FindWithTag("Score"); //find the object with the tag Score
        Debug.Log(text_score);
        Debug.Log(text_score.GetComponent<TextMeshPro>());
        text_score.GetComponent<TextMeshPro>().text = " YOU WIN! Score: " + score; //Show the score on the textmeshpro component

    }
        */
    }
}
