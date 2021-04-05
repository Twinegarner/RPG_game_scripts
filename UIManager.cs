using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HPbar;//the hp bar and slider info
    public Text HPtext;
    public PlayerHealthManager playerHealth;//call to player health
    public GameObject options;//the options object

    private PlayerStats thePS;// the player stats call
    public Text levelText;//the info on the players level text

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //get the player stats
        thePS = GetComponent<PlayerStats>();


    }

    // Update is called once per frame
    void Update()
    {
        //set up player  health
        HPbar.maxValue = playerHealth.PlayerMaxHealth;
        HPbar.value = playerHealth.PlayerHealth;
        HPtext.text = "HP: " + playerHealth.PlayerHealth.ToString() + "/" + playerHealth.PlayerMaxHealth.ToString();//get the hp and write it to the hp bar and text
        //exp
        levelText.text = "Lvl: " + thePS.currentLevel;
        //if options is hit
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!options.activeSelf)
            {
                options.SetActive(true);

            }
            
        }


    }
}
