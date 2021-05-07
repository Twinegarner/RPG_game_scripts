using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool mcExists;//bool to keep music player through sences
    public AudioSource[] musicTracks;//an array of music tracks
    public int currentTrack;//keeps track of the music order
    public bool musicCanPlay;//can the music play


    // Start is called before the first frame update
    void Start()
    {
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)//if the music can play
        {
            if (!musicTracks[currentTrack].isPlaying)//check if music is playing curentally
            {
                musicTracks[currentTrack].Play();//play the music
            }
        }
        else//if the music cant play
        {
            musicTracks[currentTrack].Stop();//stop the music
        }
    }

    public void toggleMusicPlay()
    {
        if (musicCanPlay)
        {
            musicCanPlay = false;
        }
        else
        {
            musicCanPlay = true;
        }
    }
    
    public void SwitchTrack(int newTrack)//changes the music track
    {
        musicTracks[currentTrack].Stop();//stop the music
        currentTrack = newTrack;//set the new track
        musicTracks[currentTrack].Play();//play the music

    }
}
