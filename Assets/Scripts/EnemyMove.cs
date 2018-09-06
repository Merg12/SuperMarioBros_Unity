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
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
		if(hit.distance < 0.8f)
		{
			Flip();
		}
		
	}
	void Flip()
	{
		if(XMoveDirection > 0)
		{
			XMoveDirection = -1;
		}
		else
		{
			XMoveDirection = 1;
		}
	}
}