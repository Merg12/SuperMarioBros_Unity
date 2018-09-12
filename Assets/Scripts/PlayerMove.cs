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
		PlayerRaycast();
	}

//======================================================================================================

	void PlayerMoveMethod()
	{
		//controls
		MoveX = Input.GetAxis("Horizontal");

		//so this means, you can "jump" by pressing the input but ALSO/AND as long as isGrounded (or player is on the ground) is true as well, both conditions must be met before player can jump again
		if(Input.GetButtonDown("Jump") && isGrounded == true)
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
		//now that the program knows that isGrounded can be false when player is in the air, we can make another condition/qualifier in the declaration of the jump input forcing another condition to be true along with the jump using "&&"
		GetComponent<Rigidbody2D>().AddForce(Vector2.up* PlayerJumpPower);
		isGrounded = false;
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

	//this function lets us know if our player is touching the floor or not
	//since player can jump as many times even while in the air, we will try to restrict its jumps to one by every time he touches the ground
	//we noticed that once the player touches the ground, isGrounded turns and remains true, so we placed a false condition when player jumps in that jump function
	void OnCollisionEnter2D(Collision2D HasCollided)
	{
		Debug.Log("Player has collided with " + HasCollided.collider.name);
		if(HasCollided.gameObject.tag == "Ground")
		{
			//isGrounded = true;
		}
	}

	void PlayerRaycast() //used to jump on top of enemy to kill it
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down); //raycast pointing down
		//adding "hit != null && hit.collider != null &&..." fixed the problem to where the raycast was looking for a spot to look for when jumping over the deadzone. it needed something to "hit" because we are asking for a distance and a collider. this is a hack-y way to fix this issue
		if(hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy") //enemy tag; added as long as we the hit points to isn't null/nothing
		{
			//Debug.Log("Squished Enemy");
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000); //causes player to bounce when jumping on the enemy
		}
		if(hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy") //issue with not able to jump from blocks because we can only jump from "Ground" tag; notice tag is with everything EXCEPT enemy then we can jump again; we don't need above OnCollisionEnter2D function anymore. its the same thing. Now something is allowing player to jump multiple (up to 2 extra jumps) in mid air...
		{
			isGrounded = true;
		}
	}
		
}
