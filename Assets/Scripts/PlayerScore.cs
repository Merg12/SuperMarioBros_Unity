using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private float TimeLeft = 30; //MUST be a float; won't work as an int (i tried)
	public int Player_Score = 0;
	public GameObject TimeLeftUI;
	public GameObject Player_ScoreUI;
	
	// Update is called once per frame
	void Update () {

		TimeLeft -= Time.deltaTime; //makes the countdown by seconds
		
		TimeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)TimeLeft); //displays the time
		Player_ScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + Player_Score); //displays the score
		//Debug.Log(TimeLeft); //sees if the countdown is working
		if(TimeLeft < 0.1f)
		{
			SceneManager.LoadScene("SampleScene");
		}
		
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
		if(trig.gameObject.name == "EndLevelArea")
		{
			CountScore();
		}
		if(trig.gameObject.name == "coin_01")
		{
			Player_Score += 10;
			Destroy(trig.gameObject);
		}
		Debug.Log("touched the end of the level");
	}

	void CountScore()
	{
		Player_Score += (int)(TimeLeft * 10); //normally you can't change a float back to an int but we cast'd that into an int to make it work for logging
		Debug.Log("player score: " + Player_Score);
	}
}
