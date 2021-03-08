using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerHurt;//sounds for player hurt
    public AudioSource playerKilled;//sound for player getting killed
    public AudioSource playerAttack;//sound for the sword swing

    private static bool sfxManExists;//a check for the sfx amanager

    // Start is called before the first frame update
    void Start()
    {
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
