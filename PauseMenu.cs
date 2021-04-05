using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;
    public GameObject menuToggle;
    // Start is called before the first frame update
    void Start()
    {
        //isPaused = false;//default not pasued
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))//if the options button is pressed
        {
            if(isPaused == false)//in not paused
            {

                togglePause();
                

            }
            else if(isPaused == true)//if paused
            {

                togglePause();
            }
        }
    }

    public void togglePause()//run when paused
    {
        if (isPaused)
        {
            Time.timeScale = 1;//start game
            isPaused = false;
            menuToggle.SetActive(false);
            
        }
        else
        {
            menuToggle.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;//stop game
        }
    }
}
