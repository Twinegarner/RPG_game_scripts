using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;//keeps track of the quest number/order
    public QuestManager theQM;//refrance to the quest manager

    public string startText;//the start text for the quest
    public string endText;//the end text for the quest

    public bool isItemQuest;//is it a item quest
    public string targetItem;//what item are we looking for

    public bool isEnemyQuest;//checks if enemy quest
    public string targetEnemy;//targets name
    public int enemiesToKill;//the number to kill
    private int enemyKillCount;//the amount to kill

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isItemQuest)//if item quest
        {
            if(theQM.itemCollected == targetItem)//if correct item
            {
                theQM.itemCollected = null;//clear up the item
                EndQuest();//end quest
            }
        }

        if (isEnemyQuest)
        {
            if(theQM.enemyKilled == targetEnemy)//if target is slayn
            {
                theQM.enemyKilled = null;
                enemyKillCount++;
            }
            if(enemyKillCount >= enemiesToKill)//if more then one target
            {
                EndQuest();
            }
        }
    }

    public void StartQuest()
    {
        theQM.showQuestText(startText);//pass the start text the qm

    }

    public void EndQuest()
    {
        theQM.showQuestText(endText);
        theQM.questCompleted[questNumber] = true;//set to  finish the quest
        gameObject.SetActive(false);//deactivate the quest when done 
    }
}
