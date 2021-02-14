using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;//the amount of damage 
    public GameObject damageNumber;//the amount of damage givin to the player


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")//if the enemy hits the player do something
        {
            other.gameObject.GetComponent<PlayerHealthManager>().hurtPlayer(damageToGive);//hurt players current health pool

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));//adds the damge numbers to zero
            clone.GetComponent<FloatingNumbers>().textColor = Color.red;//change the text to red
            clone.GetComponent<FloatingNumbers>().damageNumbers = damageToGive;//pass the damge number to the gamecomponet

        }



    }
}
