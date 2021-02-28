using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager theQM;//the refrance to the quest manager

    public int questNumber;//keeps track of which quest
    public bool startQuest;//start quest trigger
    public bool endQuest;//the end quest trigger


    // Start is called before the first frame update
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();//set up on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//when the player enters a loction quest zone
    {
        if(other.gameObject.name == "Player")//if the player enters
        {
            if (!theQM.questCompleted[questNumber])//is the quest completed or not
            {
                if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf)//check the quest start and check if active
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);//now activate the quest
                    theQM.quests[questNumber].StartQuest();//start the quest
                }
                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)//check the end quest and check if active
                {
                    theQM.quests[questNumber].EndQuest();//run end quest
                }
            }
        }
    }
}
