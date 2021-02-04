using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{
    public float moveSpeed;//control the number floating speed
    public int damageNumbers;//the number that will come off the enemy
    public Text displayNumber;//the text display for the UI



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = damageNumbers.ToString();//takes the damge number and converts it to string
        //transform the postion of the numbers to float up slowly then disapaer
        transform.position = new Vector3(transform.position.x,transform.position.y + (moveSpeed * Time.deltaTime),transform.position.z);

    }
}
