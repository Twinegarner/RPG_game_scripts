using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;//holds the players current lvl
    public int currentExp;//holds the exp needed for the next lvl
    public int[] toLevelUp;//an array to hold the exp needed to lvl up in the game

    public int[] hpLevels;//has how much hp the player has on each lvl
    public int[] attackLevels;//has the base attack streangth 
    public int[] defenceLevels;//gives the player more defence on each lvl up

    public int currentHP;//the players current stats
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;//add stats to the player 


    // Start is called before the first frame update
    void Start()
    {
        currentAttack = attackLevels[1];//set the stats to lvl 1 default
        currentDefence = defenceLevels[1];
        currentHP = hpLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();//find the object that has this object
    }

    // Update is called once per frame
    void Update()
    {
        //find curretn level and use it in the array
        if(currentExp >= toLevelUp[currentLevel])
        {
            currentExp -= toLevelUp[currentLevel];//save the rest of the exp for the next level
            //currentLevel++;//then update level
            levelUp();//calls the level up function to handle lvl ups
        }
    }

    //a function to take in exp
    public void addExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;//add the exp to the level system
    }

    public void levelUp()//handles the player stats on lvl up
    {
        currentLevel++;//update lvl
        currentAttack = attackLevels[currentLevel];//set the stats to lvl 1 default
        currentDefence = defenceLevels[currentLevel];
        currentHP = hpLevels[currentLevel];
        thePlayerHealth.PlayerMaxHealth = currentHP;//set the player objects health
        thePlayerHealth.PlayerHealth += currentHP - hpLevels[currentLevel - 1];//add missing hp

    }
}
