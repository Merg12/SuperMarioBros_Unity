using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public int PlayerSpeed = 10;
	public bool FacingRight = true;
	public int PlayerJumpPower = 1250;
	public float MoveX;
	public bool isGrounded;

//======================================================================================================

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		PlayerMoveMethod();
	}

//======================================================================================================

	void PlayerMoveMethod()
	{
		//controls
		MoveX = Input.GetAxis("Horizontal");

		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		//animations
		//player directions
		if(MoveX < 0.0f && FacingRight == true)
		{
			FlipPlayer();
		}
		else if(MoveX > 0.0f && FacingRight == false)
		{
			FlipPlayer();
		}
		//physics
		//QUESTION: what is this really for? what if i left it blank
		//ANSWER: oh its for moving, your player left and right... see the MoveX variable in there?
		//NOTE: you know what?! from the next question about GameObject, i tried removing that GetObject. from this code beneath and it doesn't seem to change anything either!
		GetComponent<Rigidbody2D>().velocity = new Vector2(MoveX * PlayerSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump()
	{
		//jumping code
		//QUESTION: why doesn't this one have a GameObject.<> before GetComponent?
		//ANSWER: i added gameObject to the beginning and it doesn't seem to make a difference. my guess is that it doesn't matter being a function outside the update function
		//NOTE: i found out that by changing .up to .down or .left or .right, the player would kinda skip in those respective directions. the only logical way of doing it right is using .up
		GetComponent<Rigidbody2D>().AddForce(Vector2.up* PlayerJumpPower);
	}

	void FlipPlayer()
	{
		//localScale refers to our transform component. when "scale" turns negative, our player looks to the left and when positive it looks right
		//I am still trying to figure out what !FacingRight even does, but removing it causes moving left to show player constantly flipping left AND right. while moving right is ok.
		//the rest of the code basically changes the transform component's scale to the opposite value either negative or positive
		FacingRight = !FacingRight;
		Vector2 LocalScale = transform.localScale;
		LocalScale.x *= -1;
		transform.localScale = LocalScale;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Player has collided with " + col.collider.name);
		if(col.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}
		
}
