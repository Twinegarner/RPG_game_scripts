using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource theAudio;//this connects to all audio
    private float audioLevel;//the min and max level of audio
    public float defaultAudio = 1;//this is the starting audio level (default is 1)

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();//get the audio and attach
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudioLevel(float volume)//set the volume level manually
    {
        if(theAudio == null)//quick fix to stop this script from running first 
        {
            theAudio = GetComponent<AudioSource>();//get the audio and attach
        }

        audioLevel = volume * defaultAudio;//set the volume
        theAudio.volume = audioLevel;//set the audio levels
    }
}
