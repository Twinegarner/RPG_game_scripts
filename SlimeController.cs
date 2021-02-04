using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;//controls the enemies movment speed

    private Rigidbody2D myRigidbody;//this is for the collider wiht the player and sourdings

    private bool moving;// checks if the object is moving

    public float timeBetweenMoves;//the time in between movment cycles
    private float timeBetweenMovesCounter;

    public float timeToMove;//the lenght of time the object is moving 
    private float timeToMoveCounter;

    public float timeToReload;//if payer dies then countdown to reload level
    private bool reloading;
    private GameObject thePlayer;

    private Vector3 movementDirection;//direction of movment

    // Start is called before the first frame update
    void Start()
    {
        //connect to rigidbody
        myRigidbody = GetComponent<Rigidbody2D>();
        //set counters
        timeBetweenMovesCounter = Random.Range(timeBetweenMoves * 0.75f,timeBetweenMoves * 1.25f);//gives the movment some randomness
        timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);//gives randomness feel
    }

    // Update is called once per frame
    void Update()
    {
        //now object logic if moving stop and wait if waiting then move

        if (moving)//checks if the object is moving
        {
            timeToMoveCounter -= Time.deltaTime;//count down timer
            myRigidbody.velocity = movementDirection;//movment

            if(timeToMoveCounter < 0f)//if the timer reachs 0 then stop moving and reset counter
            {
                moving = false;
                //timeBetweenMovesCounter = timeBetweenMoves;
                timeBetweenMovesCounter = Random.Range(timeBetweenMoves * 0.75f, timeBetweenMoves * 1.25f);//gives the movment some randomness
            }


        }
        else 
        {
            timeBetweenMovesCounter -= Time.deltaTime; //count down the set time
            myRigidbody.velocity = Vector2.zero;
            if(timeBetweenMovesCounter < 0f)
            {
                moving = true;//set back to true since we want to move
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);//gives randomness feel

                movementDirection = new Vector3(Random.Range(1f, -1f) * moveSpeed, Random.Range(1f, -1f) * moveSpeed, 0f);//random movment
            }
        }
        if(reloading == true)//if player dies
        {
            timeToReload -= Time.deltaTime;
            if(timeToReload < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//loads the same level
                thePlayer.SetActive(true);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.name == "Player")//if the enemy hits the player do something
        {
            
            other.gameObject.SetActive(false);//stops player movment
            reloading = true;//start reloading the level
            thePlayer = other.gameObject;//saves the player game object
        }*/



    }



}
