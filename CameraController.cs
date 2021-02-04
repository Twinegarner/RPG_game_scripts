using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //this is the target the camra follows 
    public GameObject followTarget;
    //now we need to save the postion
    private Vector3 targetPos;
    //camera speed
    public float moveSpeed;

    private static bool cameraExists = false; //static so the stat foloows on all loads


    // Start is called before the first frame update
    void Start()
    {
        //save the camra controls for the next level
        //DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists)//checks if game object already exists
        {
            cameraExists = true;
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
        //update the camera with targets infomation
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        //now ypdate with the information
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
