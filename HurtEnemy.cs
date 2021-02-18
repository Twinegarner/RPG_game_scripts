using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;//sets the damage number for the weapon
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;//gets the damge number for the floating numbers

    private PlayerStats thePS;//the players stats and info
    private int currentDamage;//the current damage to give

    // Start is called before the first frame update
    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();//find the player stats in related info
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//checks if weapons hit enemy
    {
        if(other.gameObject.tag == "Enemy")
        {
            //attack formula
            currentDamage = damageToGive + thePS.currentAttack;

            //Destroy(other.gameObject);//dont want to destroy for now
            other.gameObject.GetComponent<EnemyHealthManager>().hurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);//this adds the blood effect to the sword hits
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));//adds the damge numbers to zero
            clone.GetComponent<FloatingNumbers>().textColor = Color.white;//white for enemy damage
            clone.GetComponent<FloatingNumbers>().damageNumbers = currentDamage;//pass the damge number to the gamecomponet


        }
    }
}
