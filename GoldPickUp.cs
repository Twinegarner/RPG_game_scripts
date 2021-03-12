using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public int value;//the value of the coin
    public MoneyManager theMM;// the money manager


    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();//find the money manager
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D other)//when the player enters the coins collider
    {
        if(other.gameObject.name == "Player")//if the player walks over it collect it
        {
            theMM.addMoney(value);//add the value of the coin
            Destroy(gameObject);//get rid of coin

        }
    }
}
