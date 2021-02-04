using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float timeToDestroy;//length of time for object to be destroyed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;//the frame count down

        if(timeToDestroy <= 0)//if time reachs 0 then destroy game object
        {
            Destroy(gameObject);
        }

    }
}
