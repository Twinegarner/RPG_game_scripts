using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;//holds the players current lvl
    public int currentExp;//holds the exp needed for the next lvl
    public int[] toLevelUp;//an array to hold the exp needed to lvl up in the game


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //find curretn level and use it in the array
        if(currentExp >= toLevelUp[currentLevel])
        {
            currentExp -= toLevelUp[currentLevel];//save the rest of the exp for the next level
            currentLevel++;//then update level
        }
    }

    //a function to take in exp
    public void addExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;//add the exp to the level system
    }
}
