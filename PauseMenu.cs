using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;
    public GameObject menuToggle;
    public Button startingButton;
    private StartingButtonSelect startButton;

    void Start()
    {
        startButton = FindObjectOfType<StartingButtonSelect>();
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
        if(menuToggle.activeSelf && isPaused == false)//fix for webgl / editor errors
        {
            togglePause();
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
            if (!menuToggle.activeSelf)
            {
                menuToggle.SetActive(true);
            }
            //menuToggle.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;//stop game
            if(startingButton != null)
            {
                startButton.selectTrigger(startingButton);
            }
            
        }
    }
}
