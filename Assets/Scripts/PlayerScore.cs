using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	public float TimeLeft = 120;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		TimeLeft -= Time.deltaTime; //makes the countdown by seconds
		Debug.Log(TimeLeft);
		
	}
}
