using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;//player movement speed
    private float currentMoveSpeed;//handles the diangnal movespeed
    private bool PlayerMoving; // keeps track of player currently moving
    public Vector2 LastMove; //saves the last move of the player

    private Rigidbody2D myRigidbody2D; //gets the info from the players rigidbody2D
    private Animator anim; //gets the info from animator 
    private static bool playerExists = false; //static so the stat foloows on all loads

    private bool attacking;//keeps track if the player is attacking and the time doing it
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;//the player start point in each level
    public bool canMove;//checks if the player can move

    // Start is called before the first frame update
    
    void Start()
    {
        //gets the information of the animator the movex and moveY
        anim = GetComponent<Animator>();
        //prep the players rigidbody2d
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //save the player in muliple levels
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //no movement check
        PlayerMoving = false;

        if(!canMove)//if talking to npc stop moving 
        {
            myRigidbody2D.velocity = Vector2.zero;//stop moving
            return;
        }
        //check if attacking
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)//checks if player is moving on x axis
            {
                //the delta time is for fram rate issues movespeed is the over all player movement 
                //---transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody2D.velocity.y);
                //playermovement update
                PlayerMoving = true;
                //save last movment
                LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            }
            if (Input.GetAxisRaw("Vertical") != 0f)//checks if player is moving on y axis
            {
                //---transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                //playermovement update
                PlayerMoving = true;
                //save last movment
                LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            }
            //-------------------no movement checks-------------------------
            if (Input.GetAxisRaw("Horizontal") == 0f)//checks if player is not moving
            {
                myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") == 0f)
            {
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, 0f);
            }
            //-------------------attack anim--------------------------
            if (Input.GetKeyDown(KeyCode.J))//if the attack key "J" is pressed attack
            {
                attackTimeCounter = attackTime;//set timer
                attacking = true;//check attak
                myRigidbody2D.velocity = Vector2.zero;//limit movment
                anim.SetBool("Attack", true);//update animator

            }
            //handle the diagnale movemnt
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed / 1.414f;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }


        }

        if(attackTimeCounter > 0)//the delay between attacks
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)//once zero update animator
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }


        //set the player animation by sending the x and y values to animator
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        //sent info to anim if the player is moving
        anim.SetBool("PlayerMoving", PlayerMoving);
        //save the last movemnt
        anim.SetFloat("LastMoveX", LastMove.x);
        anim.SetFloat("LastMoveY", LastMove.y);

    }
}
