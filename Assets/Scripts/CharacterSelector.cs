using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour {
	
	public void ChooseCharacter(int characterIndex)
	{

	}

	public void LoadScene()
	{
		SceneManagager.LoadScene("SampleScene");
	}

}
