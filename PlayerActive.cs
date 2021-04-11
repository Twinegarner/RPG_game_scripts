using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActive : MonoBehaviour
{
    public GameObject player;//the objects to inactive or active
    public GameObject canvas;
    public GameObject mainCam;


    // Start is called before the first frame update
    void Start()
    {
        
            
    }

    public void loadedlevelActive (bool wantActive)//when loading next level set active or not
    {
        //if active - check if already active then do nothing
        if (wantActive)//want the players to be active on load
        {
            toggleActive(wantActive);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//load the next idex
        }
        else
        {
            toggleActive(wantActive);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//load the next idex

        }
    }
    
    public void toggleActive(bool activeForNextLvl)//toggles the active players
    {
        if (activeForNextLvl)
        {
            player.SetActive(true);
            canvas.SetActive(true);
            mainCam.SetActive(true);
           
        }
        else
        {
            player.SetActive(false);
            canvas.SetActive(false);
            mainCam.SetActive(false);
           
        }
    }
}
