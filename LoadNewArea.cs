using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;//name of the level loaded

    public string exitPoint;//the name of the point the player exits to

    private PlayerController thePlayer;//refrance to the player controller for spawn points


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();//get the player info
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
            thePlayer.startPoint = exitPoint;//tells the players start point to the exit point
        }
    }
}
