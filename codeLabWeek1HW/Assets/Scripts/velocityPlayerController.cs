using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    //speed and jump (change in inspector)
    public float maxSpeed;
    public float jumpForce;
    
    //ground check to prevent player from jumping in the air
    private bool grounded = false;
    public Transform groundCheck; //made child object of player gameobject to check if it is on ground
    public float groundRadius = 1f;
    public LayerMask whatIsGround; //what the player can land on; made a new ground layer (user layer 8)
    
    //controls
    public KeyCode jump;
    //left and right controls are controlled using input.getaxis (see line 29-32)
    
    //ui stuff
    public int score = 0;
    public TextMesh scoreText;

    public int lives = 3;
    public TextMesh livesText;

    public TextMesh winnerText;
    public float winnerTextX;
    public float winnerTextY;
    public float winnerTextZ;
    
    public TextMesh loserText;
    public float loserTextX;
    public float loserTextY;
    public float loserTextZ;
    
    //for gravity while falling, i referred to: https://www.youtube.com/watch?v=7KiK0Aqtmzc
    public float fallMultiplier; //affects the gravity when the character falls after jumping
    public float lowJumpMultiplier; //affects the gravity when player does a low jump
    
    //public Vector3 playerPosition;
    //text offset
    public float winnerOffsetX;
    public float winnerOffsetY;
    public float loserOffsetX;
    public float loserOffsetY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //playerPosition = new Vector3(rb.transform.position.x, rb.transform.position.y, transform.position.z);
        
        //checking if player is on ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        //checking score
        scoreText.text = "score: " + score;
        if (score == 5)
        {    
            winnerText.transform.position = new Vector3(rb.position.x - winnerOffsetX, rb.position.y + winnerOffsetY); //moves text to correct position
            Time.timeScale = 0; //stop time, pause game
            Debug.Log("winner");
        }
		
        //if all lives are lost
        livesText.text = "lives: " + lives;
        if (lives == 0)
        {
            loserText.transform.position = new Vector3(rb.position.x - loserOffsetX, rb.position.y + loserOffsetY, loserTextZ);
            Time.timeScale = 0;
            Debug.Log("loser");
			
        } 
    }
    
    void FixedUpdate() //contains all physics 
    {
        //move controls
        float moveDirection = Input.GetAxis("Horizontal"); //checks to see if player is going left (a/left arrow) or right (d/right arrow)
        rb.velocity = new Vector2(moveDirection*maxSpeed, rb.velocity.y);
        
        //setting up jump
        if (grounded && Input.GetKeyDown(jump)) //jump only when player is on ground and pressing jump
        {
            rb.AddForce(new Vector2(0, jumpForce)); //force is added on y axis
        }
        
        //adding gravity force when player falls after jumping (referred to youtube tutorial)
        //if playerController is jumping
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
        //doesn't seem to work...
        else if (rb.velocity.y > 0 && Input.GetKeyUp(jump))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
