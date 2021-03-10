using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public VolumeController[] vcObjects;//holds all the audio controller objects
    public float maxVolumeLevel = 1.0f;//max volume
    public float currentVolumeLevel;//the current volume levels

    // Start is called before the first frame update
    void Start()
    {
        vcObjects = FindObjectsOfType<VolumeController>();//set up refrance
        if(currentVolumeLevel > maxVolumeLevel)//safty net for volume
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        for(int i = 0; i < vcObjects.Length; i++)//loop through array
        {
            vcObjects[i].SetAudioLevel(currentVolumeLevel);//set the audio levels
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
