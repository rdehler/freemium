using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int numClicks;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), "Clicks: " + numClicks);
	}

	void Start() {
		Debug.Log ("Loading from save file");
		Load ();
	}

	public void Save() {
		Debug.Log ("Saving to file...");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.numClicks = numClicks;

		bf.Serialize(file, data);

		file.Close();
	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);

			file.Close ();

			numClicks = data.numClicks;
		}
	}
}

[Serializable]
class PlayerData {
	public int numClicks;
}