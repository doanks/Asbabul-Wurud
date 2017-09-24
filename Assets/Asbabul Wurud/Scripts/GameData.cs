using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameData : MonoBehaviour {

	public static GameData instance;

	public Data data;

	void Awake(){
		Makeinstance();
	}

	void Makeinstance(){
		if (instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	void Start(){
		Initialize();
	}

	void Initialize (){

		//DeleteGameData();
		Load();

		if (!data.firstPlayThisGame){

			FirstData ();
			Save();
		}
	}

	void FirstData () {
		
		data.firstPlayThisGame = true;

		data.playerSelected = 0;
		data.coin = 0;
		data.bestScore = 0;
	}

	public void Save () {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/asdasd.dat");
		bf.Serialize(file, data);
		file.Close();
	}

	void Load () {

		FileStream file = null;
		try{
			BinaryFormatter bf = new BinaryFormatter();
			file = File.Open(Application.persistentDataPath + "/asdasd.dat", FileMode.Open);
			data = (Data)bf.Deserialize(file);
		}
		catch(Exception e){}
		finally{
			if (file != null)
				file.Close();
		}
	}

	void DeleteGameData(){
		File.Delete(Application.persistentDataPath + "/GameData.dat");
	}
}

[Serializable]
public class Data{

	public bool firstPlayThisGame;

	public int playerSelected;
	public int coin;
	public int bestScore;
}