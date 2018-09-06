using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public int EnemySpeed;
	public int XMoveDirection;
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
		
	}
}
