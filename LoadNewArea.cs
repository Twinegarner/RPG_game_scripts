﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//find the trigger when the player walks over trigger box
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
