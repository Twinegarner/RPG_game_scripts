using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParentHolder : MonoBehaviour
{

    private static bool parentExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!parentExists)
        {
            parentExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
