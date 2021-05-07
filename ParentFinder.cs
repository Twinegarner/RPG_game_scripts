using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFinder : MonoBehaviour
{
    public void volumeLevel(float volume)//find the parent and then find the music to change volume
    {
        ParentHolder pHolder = FindObjectOfType<ParentHolder>();//grab the parent
        GameObject childVolume = pHolder.transform.GetChild(3).gameObject;//find the child of the music manager

        childVolume.GetComponent<VolumeManager>().setAduioLevel(volume);//grab the volume controller and set the volume

    }
}
