using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;//the dialogue that the npc will use 
    private DialogueManager dMan;//the dialogue manager that will be called

    public string[] dialogueLines;//holds the dialogue lines

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();//find and set up the dialogue manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)//when the player enters the area and presses spacebar active the dialog
    {
        if(other.gameObject.name == "Player")//checks the player tag
        {
            if (Input.GetKeyUp(KeyCode.Space))//if space is pressed
            {
                //dMan.ShowBox(dialogue);//the dialoge we passed 

                if(!dMan.dialogueActive)//checks if dialogue is active
                {
                    dMan.dialogueLines = dialogueLines;//pass the dialogue lines
                    dMan.currentLine = 0;//default the lines to the beggining
                    dMan.ShowDialogue();//show the npcs dialogue
                }

                if(GetComponentInParent<VillagerMovement>() != null)//if there is a npc movment on the scrpit then stop
                {
                    GetComponentInParent<VillagerMovement>().canMove = false;//stop moving
                }
            }
        }
    }
}
