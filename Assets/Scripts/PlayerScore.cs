using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private float TimeLeft = 30; //MUST be a float; won't work as an int (i tried)
	public int player_Score = 0;
	
	// Update is called once per frame
	void Update () {

		TimeLeft -= Time.deltaTime; //makes the countdown by seconds
		Debug.Log(TimeLeft); //sees if the countdown is working
		if(TimeLeft < 0.1f)
		{
			SceneManager.LoadScene("SampleScene");
		}
		
	}
}
