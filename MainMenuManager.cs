﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void playGame()//play button play first level
    {
        SceneManager.LoadScene(1);//load the intro level
    }

    public void quitGame()
    {
        Application.Quit();//quit the game
    }


}
