using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;//the dialogue box
    public Text dText;//the dialogue text box

    public bool dialogueActive;//checks if the dialogue is ative

    public string[] dialogueLines;//an array of dialogue
    public int currentLine;//holds the current line in the dialogue array

    private PlayerController thePlayer;//used to stop the player during dialogue

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();//set the playercontroller
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive && Input.GetKeyDown(KeyCode.Space))//if dialog is active and the player presses space
        {
            //dBox.SetActive(false);//hide the dialogue box
            //dialogueActive = false;//set the flag to false since the user pressed space

            currentLine++;//move to the next line of dialogue in the array

        }
        if(currentLine >= dialogueLines.Length)//once at the end of the dialogue array
        {
            dBox.SetActive(false);//hide the dialogue box
            dialogueActive = false;//set the flag to false since the user pressed space

            currentLine = 0;//set back to start of dialogue box
            thePlayer.canMove = true;//player can now move again
        }
        dText.text = dialogueLines[currentLine];//set the current line to the dialogue array
    }

    public void ShowBox(string dialogue)//function to pop up the dialogue box
    {
        dialogueActive = true;//set and ready for the dialogue box 
        dText.text = dialogue;//the dialogue that is being sent
        dBox.SetActive(true);//set the active dialog box

    }

    public void ShowDialogue ()//shows a dialogue array for the npc
    {
        dialogueActive = true;//set and ready for the dialogue box 
        dBox.SetActive(true);//set the active dialog box
        thePlayer.canMove = false;//stop the players movment for dialogue

    }
}
