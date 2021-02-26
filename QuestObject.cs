using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;//keeps track of the quest number/order
    public QuestManager theQM;//refrance to the quest manager

    public string startText;//the start text for the quest
    public string endText;//the end text for the quest



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
