using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour {

	public float speed;
	private float pos;
	
	// Update is called once per frame
	void Update () {

		pos =+ speed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);
		
	}
}

//to see what's changed we changed the prefab image of the background wrap mode to repeat and if you go to the "quad" inspector and change the speed, you'll notice the background moving