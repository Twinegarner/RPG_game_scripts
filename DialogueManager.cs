using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;//the dialogue box
    public Text dText;//the dialogue text box

    public bool dialogueActive;//checks if the dialogue is ative

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive && Input.GetKeyDown(KeyCode.Space))//if dialog is active and the player presses space
        {
            dBox.SetActive(false);//hide the dialogue box
            dialogueActive = false;//set the flag to false since the user pressed space
        }
    }

    public void ShowBox(string dialogue)//function to pop up the dialogue box
    {
        dialogueActive = true;//set and ready for the dialogue box 
        dText.text = dialogue;//the dialogue that is being sent
        dBox.SetActive(true);//set the active dialog box

    }
}
