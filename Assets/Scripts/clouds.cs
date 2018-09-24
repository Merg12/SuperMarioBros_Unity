using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes the clouds move on their own, adds cool effect

public class clouds : MonoBehaviour {

	public float speed;
	private float xDir;

	// Use this for initialization
	void Start () {
		xDir = transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		xDir -= Time.deltaTime * speed;
		transform.position = new Vector3(xDir, transform.position.y, transform.position.z);
		
		//make clouds revert back to the front when it leaves the area
		if(transform.position.x < -4) //must use < a number and not == to a number
		{
			transform.position = new Vector3(10, transform.position.y, transform.position.x); //problem here is that after it resets to 10, it doesn't seem to move anymore
		}

	}
}
