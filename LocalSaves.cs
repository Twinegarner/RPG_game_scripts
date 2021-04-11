using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSaves : MonoBehaviour
{
   public void volumeSave(float number)//saves the volume level 1-0
    {
        PlayerPrefs.SetFloat("volume", number);
    }
    public float volumeLoad()//returns a float of the volume
    {
        return PlayerPrefs.GetFloat("volume");
    }


}
