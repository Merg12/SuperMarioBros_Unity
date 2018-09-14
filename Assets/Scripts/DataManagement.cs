using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //for encrypting
using System.IO; //for encrypting
using System.Runtime.Serialization.Formatters.Binary; //for encrypting

//this is for saving and loading the game. the simpliest way is to use "player prefs" from Unity: using "Setint" and "Getint"
//PlayerPrefs.SetInt("HighScore", 10); PlayerPrefs.GetInt("HighScore");

public class DataManagement : MonoBehaviour {
	public static DataManagement datamanagement;
	public int highScore;
	
	//singleton design pattern where this object stays within the scene, level to level and everytime we save data, it gets saved to this gameObject
	void Awake()
	{
		if(datamanagement == null)
		{
			DontDestroyOnLoad(gameObject);

			datamanagement = this;
		}
		else if(datamanagement != this)
		{
			Destroy(gameObject);
		}
	}

	//we want to create 2 methods, a SaveData and a LoadData()

	public void SaveData()
	{
		BinaryFormatter BinForm = new BinaryFormatter(); //this creates a binary formatter
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //this creates file
		gameData data = new gameData(); //creates container for data
		data.highscore = highScore;
		BinForm.Serialize(file, data); //serializes file and data
		file.Close(); //closes file
	}

	public void LoadData()
	{
		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			BinaryFormatter BinForm = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			gameData data = (gameData)BinForm.Deserialize(file);
			file.Close();
			highScore = data.highscore;
		}
	}
}

[Serializable]
class gameData //when we actually save data, we will be actually saving this class
{
	public int highscore;
}
