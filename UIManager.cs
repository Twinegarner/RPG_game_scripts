using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HPbar;
    public Text HPtext;
    public PlayerHealthManager playerHealth;

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


    }

    // Update is called once per frame
    void Update()
    {
        //set up player  health
        HPbar.maxValue = playerHealth.PlayerMaxHealth;
        HPbar.value = playerHealth.PlayerHealth;
        HPtext.text = "HP: " + playerHealth.PlayerHealth.ToString() + "/" + playerHealth.PlayerMaxHealth.ToString();
    }
}
