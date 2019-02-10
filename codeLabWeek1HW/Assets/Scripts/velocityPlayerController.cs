using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityPlayerController : MonoBehaviour
{
    //speed and jump (change in inspector)
    public float maxSpeed = 10;
    public float jumpForce = 200;
    
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
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {   
        //move controls
        float moveDirection = Input.GetAxis("Horizontal"); //checks to see if player is going left (a/left arrow) or right (d/right arrow)
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection*maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        
        //setting up jump
        if (grounded && Input.GetKeyDown(jump)) //jump only when player is on ground and pressing jump
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce)); //force is added on y axis
        }
        
        //checking if player is on ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        //checking score
        scoreText.text = "score: " + score;
        if (score == 5)
        {    
            winnerText.transform.position = new Vector3(winnerTextX, winnerTextY, winnerTextZ); //moves text to correct position
            Time.timeScale = 0; //stop time, pause game
            Debug.Log("winner");
        }
		
        //if all lives are lost
        livesText.text = "lives: " + lives;
        if (lives == 0)
        {
            loserText.transform.position = new Vector3(loserTextX, loserTextY, loserTextZ);
            Time.timeScale = 0;
            Debug.Log("loser");
			
        }
        
    }
}
