using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    //need to save the player and camera
    private PlayerController thePlayer;
    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;//the player starting point 

    // Start is called before the first frame update
    void Start()
    {
        //find the objects on start the player and camera
        theCamera = FindObjectOfType<CameraController>();
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = transform.position; //get the new postion of the starting point
                                                               //save player direction
            thePlayer.LastMove = startDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
