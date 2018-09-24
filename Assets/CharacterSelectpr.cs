using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public void ChooseCharacter(int characterIndex)
	{

	}

	public void LoadScene()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
