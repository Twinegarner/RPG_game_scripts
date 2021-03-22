using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingButtonSelect : MonoBehaviour
{
    public Button button;//the button to select on start or transtion
    public bool awakeOnStart;//dose the button awake on load
    

    // Start is called before the first frame update
    void Start()
    {
        if (awakeOnStart)//if awake is press then once on start
        {
            button.Select();
        }
    }

   public void selectTrigger(Button other)//trigger the select button NOTE: only for button actions
    {
        other.Select();
    }
}
