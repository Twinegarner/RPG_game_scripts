using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;// a holder for the quest array
    public bool[] questCompleted;//keeps track of completed quest

    public DialogueManager theDM;//the dialogue manager for dialogue

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[questCompleted.Length];//make an array the size of quests
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showQuestText(string questText)//function that uses manager for text
    {
        theDM.dialogueLines = new string[1];//remake the array
        theDM.dialogueLines[0] = questText;//add the quest text

        theDM.currentLine = 0;//reset the line 
        theDM.ShowDialogue();//display the box

    }
}
