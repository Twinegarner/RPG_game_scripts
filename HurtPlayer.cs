using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;//the amount of damage 
    public GameObject damageNumber;//the amount of damage givin to the player

    private PlayerStats thePS;//get the player stats
    private int currentDamage;//hold the current damage


    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();//find andd set the player stats
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")//if the enemy hits the player do something
        {
            currentDamage = damageToGive - thePS.currentDefence;
            if (currentDamage <= 0)//always to 1 damage
            {
                currentDamage = 1;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().hurtPlayer(currentDamage);//hurt players current health pool

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));//adds the damge numbers to zero
            clone.GetComponent<FloatingNumbers>().textColor = Color.red;//change the text to red
            clone.GetComponent<FloatingNumbers>().damageNumbers = currentDamage;//pass the damge number to the gamecomponet

        }



    }
}
