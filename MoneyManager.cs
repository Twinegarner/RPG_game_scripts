using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;//the text to tell the player how much money they have
    public int currentGold;//the value that the player has currently


    // Start is called before the first frame update
    void Start()
    {
        currentGold = 0;//on start the player has zero gold

        moneyText.text = "Gold: " + currentGold;//set the text for starting game
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void addMoney(int goldToAdd)//public function to add and update the HUD
    {
        currentGold += goldToAdd;//add up the gold
        moneyText.text = "Gold: " + currentGold;//set the text for starting game
    }
}
