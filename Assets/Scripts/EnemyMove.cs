using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public int EnemySpeed;
	public int XMoveDirection;
	
	// Update is called once per frame
	void Update () {
		//apparently this raycast shoots out a ray from the very center of the gameobject/player/enemy and whatever other object it touches in the game, you can make it do certain things
		//
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed; //move in a direction
		if(hit.distance < 0.9f) //this is how far from the enemy to the wall that determines when the enemy should start moving the other direction
		{
			Flip();
			//Destroy(hit.collider.gameObject); if this line exist its used to destroy anything the enemy touches instead we will use more specific...
			if(hit.collider.tag == "Player") //only works if Player layer on "default" instead of "ignore raycast"
			{
				//Debug.Log("enemy hit player");
				Destroy(hit.collider.gameObject);
			}	
		}

		//TODO fix this desgusting code
		//so this error'd because contraindicated with playermove script line that diabled movescript
		//f(gameObject.transform.position.y < -50)
		//{
			//Debug.Log("enemy is 50 down!");
			//Destroy(gameObject);
		//}
		
	}
	void Flip()
	{
		if(XMoveDirection > 0)
		{
			XMoveDirection = -1; //the negative sign makes anything direction turn opposite
		}
		else
		{
			XMoveDirection = 1;
		}
	}
}