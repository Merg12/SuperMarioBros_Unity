using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		if(gameObject.transform.position.y < -7) //kills the enemy if they end up being -7 below
		{
			//Debug.Log("Player Has Died!(Update)");
			Destroy(gameObject);
		}
	}
}
