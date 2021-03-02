using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public int questNumber;//keeps track of the quest number

    private QuestManager theQM;//refrance to the qm

    public string itemName;//the item the player is collecting


    // Start is called before the first frame update
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();//find and set the quest manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")//only player walks on object
        {
            if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)//checks if quest is completed and active
            {
                theQM.itemCollected = itemName;//set the item name
                gameObject.SetActive(false);//turn off item
            }
        }
    }


}
