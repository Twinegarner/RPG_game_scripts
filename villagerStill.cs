using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villagerStill : MonoBehaviour
{
    private Rigidbody2D myRigidbody;//sets the rigid boday of the npc
    private DialogueManager theDM;//the refrance to the dialogue manager
    private Vector2 minFacePoint;//the edges of the face zone
    private Vector2 maxFacePoint;
    private Animator anim; //gets the info from animator 
    //private GameObject
    //---private---
    //public Collider2D faceZone;//npc face zone limit
   


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//get and set the rigidbody componet
        theDM = FindObjectOfType<DialogueManager>();//finds the dialogue manager
        anim = GetComponent<Animator>();

        //minFacePoint = faceZone.bounds.min;//gets the lower corner of the zone
        //maxFacePoint = faceZone.bounds.max;//gets the upper corner of the zone

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)//when the player enters the collider
    {
        if (other.gameObject.name == "Player")//if the player walks in the space move npc animations
        {
            if (Input.GetKeyDown(KeyCode.Space))//if the user inter acts with npc
            {

                float playerX, PlayerY,npcX,npcY;//holds the players x and y point
                playerX = other.gameObject.transform.position.x;//gets the players locations
                PlayerY = other.gameObject.transform.position.y;
                npcX = this.transform.position.x;//this is the npcs location
                npcY = this.transform.position.y;
                //aglo goes here to face the npc
                anim.SetFloat("LastX", playerX - npcX);
                anim.SetFloat("LastY", PlayerY - npcY);

                
                

            }

        }
    }
}
