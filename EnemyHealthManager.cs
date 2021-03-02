using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;//values to keep track of players health
    public int CurrentHealth;

    private PlayerStats thePlayerStats;//gets the player stats
    public int expToGive;//the amount of exp

    public string enemyQuestName;//if part of a quest
    private QuestManager theQM;//the refrance to the quest manager


    // Start is called before the first frame update
    void Start()
    {
        //set up player health
        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();//find the object player stats
        theQM = FindObjectOfType<QuestManager>();//find object of quest manager
    }

    // Update is called once per frame
    void Update()
    {
        //player death condtion
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;//if quest is asking for the enemy killed
            Destroy(gameObject);//gets rid of the enemy
            //now give exp
            thePlayerStats.addExperience(expToGive);

        }
    }
    //control the player taking damage
    public void hurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }
    //conrtol player healing health
    public void setMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
