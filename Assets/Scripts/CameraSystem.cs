using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	public GameObject player;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	// Use this for initialization
	void Start () {

		if(GameObject.FindGameObjectWithTag("Player") != null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if(GameObject.FindGameObjectWithTag("Player") != null)
		{
			//creates a limit to where the camera can move, allowing us to change the limits
			float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
			float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

			//makes our camera position itself to our player; moves with player keeping player in the center until a min or max is reached
			//I still don't understand the difference between vector2 and vector 3 and why this 2D game even considers using vector3
			//but i guess that since the z variable needs to remain constant, we create vector3 to keep it constant
			//after reading more about .Clamp function, it seems to keep player positions x and y axis between the min and max of respective axis
			//thus keeping the player in the middle of the camera viewfinder
			gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
		}
	}
}
