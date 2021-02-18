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


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//get and set the rigidbody componet
        waitCounter = waitTime;//set timers
        walkCounter = walkTime;

        chooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)//if the player is walking set time
        {
            walkCounter -= Time.deltaTime;//count down
            
            switch (walkDirection)//movment in a direction
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
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
            myRigidbody.velocity = Vector2.zero;

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
