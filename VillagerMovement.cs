using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;//sets the npc move speed

    private Rigidbody2D myRigidbody;//sets the rigid boday of the npc

    public bool isWalking;//checks if npc is moveing or not
    public float waitTime;//wait inbetween movments
    public float walkTime;//the time/ distance of movment
    private float waitCounter;//counters for the timer
    private float walkCounter;
    private int walkDirection;//choose a walk direction for the npc 0=up,1=right,2=down,3=left

    public Collider2D walkZone;//npc walk zone limit
    private Vector2 minWalkPoint;//the edges of the walk zone
    private Vector2 maxWalkPoint;
    private bool hasWalkZone = false;

    public bool canMove;//checks if the npc can move during cutsences
    private DialogueManager theDM;//the refrance to the dialogue manager

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//get and set the rigidbody componet
        theDM = FindObjectOfType<DialogueManager>();//finds the dialogue manager
        waitCounter = waitTime;//set timers
        walkCounter = walkTime;

        chooseDirection();//random direction
        if (walkZone != null)//if no zone then walk anywhere
        {
            minWalkPoint = walkZone.bounds.min;//gets the lower corner of the zone
            maxWalkPoint = walkZone.bounds.max;//gets the upper corner of the zone
            hasWalkZone = true;//limits checks
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!theDM.dialogueActive)
        {
            canMove = true;//any can move
        }

        if(!canMove)//if can not move then set movment to zero
        {
            myRigidbody.velocity = Vector2.zero;//stop movment
            return;//jump out
        }

        if (isWalking)//if the player is walking set time
        {
            walkCounter -= Time.deltaTime;//count down
            
            switch (walkDirection)//movment in a direction
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);//moving up
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)//if limited area then tell it to stop
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);//moving right
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)//if limited area then tell it to stop
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);//moving down
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)//if limited area then tell it to stop
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);//moving left
                    if (hasWalkZone && transform.position.x < maxWalkPoint.x)//if limited area then tell it to stop
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                       
                    }
                    break;
            }

            if (walkCounter < 0)//once the timer is zero stop walking
            {
                isWalking = false;//stop walking
                waitCounter = waitTime;//set wait time
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;//wait time counting down
            myRigidbody.velocity = Vector2.zero;//set back to zero

            if(waitCounter < 0)
            {
                chooseDirection();//call this function to choose a direction and walk
            }
        }
    }

    public void chooseDirection()//choose the direction of the npc
    {
        walkDirection = Random.Range(0, 4);//give a random direction
        isWalking = true;//set is walking
        walkCounter = walkTime;//reset walk counter

    }
}
