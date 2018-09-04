using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int health;
	public bool HasDied;

	// Use this for initialization
	void Start () {

		HasDied = false; //player has not yet died
		
	}
	
	// Update is called once per frame
	void Update () {

		if(gameObject.transform.position.y < -7)
		{
			Debug.Log("Player Has Died!(Update)");
			HasDied = true;
		}
		if(HasDied == true)
		{
			StartCoroutine("Die");
		}
		
	}

	//as you can see from the previous line start Co-routine to Die actually moves the work to IEnumerator function to die
	IEnumerator Die()
	{
		SceneManager.LoadScene("SampleScene");
		yield return null;
		//Debug.Log("Player has Fallen!");
		//yield return new WaitForSeconds(2);
		//Debug.Log("Player has Died!(IEnumeratorDie)");
	}
}
