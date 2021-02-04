using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;//values to keep track of players health
    public int CurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        //set up player health
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //player death condtion
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);//gets rid of the enemy

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
