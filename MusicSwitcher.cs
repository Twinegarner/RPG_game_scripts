using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private MusicController theMC;//ref to the music controller
    public int newTrack;//the new track for the zone
    public bool switchOnStart;//will the track switch on level start
    

    // Start is called before the first frame update
    void Start()
    {
        theMC = FindObjectOfType<MusicController>();//set up music contoller

        if(switchOnStart)//if true then switch on new secne
        {
            theMC.SwitchTrack(newTrack);//switch to new track
            gameObject.SetActive(false);//turn off the zone to stop repeats
        }
    }

    

    void OnTriggerEnter2D(Collider2D other)//if enter a zone with special music
    {
        if(other.gameObject.name == "Player")//if player enters the track zone
        {
            theMC.SwitchTrack(newTrack);//switch to new track
            gameObject.SetActive(false);//turn off the zone to stop repeats
        }
    }
}
