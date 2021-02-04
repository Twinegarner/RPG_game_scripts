using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int PlayerMaxHealth;//values to keep track of players health
    public int PlayerHealth;


    // Start is called before the first frame update
    void Start()
    {
        //set up player health
        PlayerHealth = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //player death condtion
        if(PlayerHealth <= 0)
        {
            gameObject.SetActive(false);//turns off the player

        }
    }
    //control the player taking damage
    public void hurtPlayer(int damageToGive)
    {
        PlayerHealth -= damageToGive;
    }
    //conrtol player healing health
    public void setMaxHealth()
    {
        PlayerHealth = PlayerMaxHealth;
    }
}
