using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void playGame()//play button play first level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//load the intro level
    }

    public void quitGame()
    {
        Application.Quit();//quit the game
    }

    public void restartMain()//restart to the main menu
    {
        SceneManager.LoadScene(1);//load the intro level
    }

    public void findParentHolder(bool wantActive)
    {
        ParentHolder pHolder = FindObjectOfType<ParentHolder>();//grab the parent
        if (wantActive)
        {
            GameObject child0 = pHolder.transform.GetChild(0).gameObject;//find the child
            GameObject child1 = pHolder.transform.GetChild(1).gameObject;
            GameObject child2 = pHolder.transform.GetChild(2).gameObject;

            child0.SetActive(true);
            child1.SetActive(true);//set to true
            child2.SetActive(true);
        }
        else
        {
            GameObject child0 = pHolder.transform.GetChild(0).gameObject;//find the child
            GameObject child1 = pHolder.transform.GetChild(1).gameObject;
            GameObject child2 = pHolder.transform.GetChild(2).gameObject;

            child0.SetActive(false);
            child1.SetActive(false);//set to true
            child2.SetActive(false);
        }
    }


}
