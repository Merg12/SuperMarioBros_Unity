using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour {
	public static DataManagement datamanagement;
	public int HighScore;
	
	//singleton design pattern where this object stays within the scene level to level and everytime we save data, it gets saved to this gameObject
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

	public void SaveData()
	{
		BinaryFormatter Binform = new BinaryFormatter(); //this creates a binary formatter
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //this creates file
		gameData data = new gameData(); //creates container for data
		data.highscore = HighScore;
		Binform.Serialize(file, data); //serializes
		file.Close(); //closes file
	}

	public void LoadData()
	{
		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			BinaryFormatter Binform = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			gameData data = (gameData)Binform.Deserialize(file);
			file.Close;
			highscore = data.HighScore;
		}
	}
}

[Serializable]
class gameData //when we actually save data, we will be actually saving this class
{
	public int HighScore;
}
