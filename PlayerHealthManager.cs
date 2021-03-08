using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int PlayerMaxHealth;//values to keep track of players health
    public int PlayerHealth;//player total current health

    private bool flashActive;//checks if the player is hit and is flashing
    public float flashLength;//the duration of the hurt playere flashing
    private float flashCounter;// the timer for the flashing player

    private SpriteRenderer playerSprite;//the player object to change alpha

    private SFXManager sfxMan;//sound effect manager

    // Start is called before the first frame update
    void Start()
    {
        //set up player health
        PlayerHealth = PlayerMaxHealth;
        //set player sprite
        playerSprite = GetComponent<SpriteRenderer>();
        //set the sound effect manager
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //player death condtion
        if(PlayerHealth <= 0)//if player dies
        {
            sfxMan.playerKilled.Play();//player killed sound
            gameObject.SetActive(false);//turns off the player

        }

        if (flashActive)//if player gets hit flash for a time
        {
            if(flashCounter > flashLength * .66f)//if over two thirds of the set the time
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);//set the alpha to full to check

            }else if (flashCounter > flashLength * .33f)//if the time is over one third of set time
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);//set the alpha to full to check
            }else if (flashCounter > 0f)//if its lower then a third
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);//set the alpha to full to check
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);//set the alpha to full to check


                flashActive = false;//stop flashing
            }

            //count down time
            flashCounter -= Time.deltaTime;
        }
    }
    //control the player taking damage
    public void hurtPlayer(int damageToGive)
    {
        PlayerHealth -= damageToGive;//damage to player

        flashActive = true;
        flashCounter = flashLength;//set the length of the flashing
        sfxMan.playerHurt.Play();//play plyer damage 


    }
    //conrtol player healing health
    public void setMaxHealth()
    {
        PlayerHealth = PlayerMaxHealth;//fill the player health to full...potion of lvl up
    }
}
