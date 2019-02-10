using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	private Rigidbody2D rb;
	public float forceAmount = 1;

	public int score = 0;
	public TextMesh scoreText;

	public int lives = 3;
	public TextMesh livesText;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 newForce = new Vector2(0,0); //the force we add to the player
		
		if (Input.GetKey(upKey))
		{
			newForce.y += 1;
		}

		if (Input.GetKey(downKey))
		{
			newForce.y -= 1;
		}

		if (Input.GetKey(leftKey))
		{
			newForce.x -= 1;
		}

		if (Input.GetKey(rightKey))
		{
			newForce.x += 1;
		}
		
		rb.AddForce(newForce);
		
		//checking scores
		scoreText.text = "score: " + score;
		if (score == 10)
		{
			Time.timeScale = 0; //stop time, pause game
			Debug.Log("winner");
		}
		
		//if all lives lost
		livesText.text = "lives: " + lives;
		if (lives == 0)
		{
			Time.timeScale = 0;
			Debug.Log("loser");
			
		}
	}
}
