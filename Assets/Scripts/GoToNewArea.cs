using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNewArea : MonoBehaviour {

	public GameObject sp1, sp2;
	public static bool canTransport;

	void Start()
	{
		canTransport = true;
		sp1 = this.gameObject;
	}

	//void OnTriggerStay2d(Collider2D trig) //this part allows play to activate the teleporter when pressing the jump button while staying inside the teleportation area
	//{
		//if(Input.GetButtonDown("Jump"))
		//{
			//trig.gameObject.transform.position = sp2.gameObject.transform.position;
		//}
	//}

	void OnTriggerEnter2D(Collider2D trig)
	{
		//print("hit"); //tests to see if we made contact successfully
		if(canTransport == true) //without this condition, your player would be stuck in limbo
		{
			trig.gameObject.transform.position = sp2.gameObject.transform.position; //alone, this will cause the player to teleport to back and forth and you get stuck in this limbo
			canTransport = false;
		}
	}
	void OnTriggerExit2D(Collider2D trig) //wait until player leaves the zone then restart the ability to teleport
	{
		canTransport = true;
	}

}
