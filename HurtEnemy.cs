using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;//sets the damage number for the weapon
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;//gets the damge number for the floating numbers

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//checks if weapons hit enemy
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);//dont want to destroy for now
            other.gameObject.GetComponent<EnemyHealthManager>().hurtEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);//this adds the blood effect to the sword hits
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));//adds the damge numbers to zero
            clone.GetComponent<FloatingNumbers>().textColor = Color.white;//white for enemy damage
            clone.GetComponent<FloatingNumbers>().damageNumbers = damageToGive;//pass the damge number to the gamecomponet


        }
    }
}
