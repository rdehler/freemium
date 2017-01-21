using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int numClicks;
	public DateTime lastClick;
	public int lastLevelCompleted;

	double millisecs;

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
		GUI.Label (new Rect (10, 40, 250, 30), "Time: " + lastClick);
		TimeSpan span = -(System.DateTime.Now - lastClick - System.TimeSpan.FromMilliseconds (millisecs));
		if (span.Seconds < 0) {
			span = System.TimeSpan.FromMilliseconds (0);
		}
		GUI.Label (new Rect (10, 70, 250, 30), "Time Left: " + formatTimeFromSeconds(span));
		if (hasBeenLongEnough()) {
			GUI.Label (new Rect (10, 100, 250, 30), "It's been long enough!");
		}
	}

	public bool hasBeenLongEnough() {
		millisecs = Constants.DEMO_TIMER;
		for (int i = 0; i < numClicks; i++) {
			millisecs *= Constants.DEMO_MULTIPLIER;
		}
		//Debug.Log ("Millisecs is " + millisecs);
		return System.DateTime.Now - lastClick > System.TimeSpan.FromMilliseconds (millisecs);
	}

	// i'm sure there's a better way to do this, but it's 1:52 am :)
	string formatTimeFromSeconds(System.TimeSpan span) {
		string ret = "";
		int secs = span.Seconds;
		int mins = span.Minutes, hours = span.Hours, days = span.Days;
		ret = secs + " second"+(secs != 1 ? "s" : "");
		if (mins > 0 && mins % 60 != 0) {
			ret = mins + " minute"+(mins != 1 ? "s" : "")+", " + ret;
		}

		if (hours > 0 && hours % 24 != 0) {
			ret = hours + " hour"+(hours != 1 ? "s" : "")+", " + ret;
		}
		if (days > 0) {
			ret = days + " day"+(days != 1 ? "s" : "") + ", " + ret;
		}
		return ret;
	}

	void Start() {
		Load ();
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.numClicks = numClicks;
		lastClick = System.DateTime.Now;
		data.lastClick = lastClick;
		data.lastLevelCompleted = lastLevelCompleted;

		bf.Serialize(file, data);

		file.Close();
	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);

			file.Close ();
			//TODO: default these values if unset
			numClicks = data.numClicks;

			lastClick = data.lastClick;
			lastLevelCompleted = data.lastLevelCompleted;
		}
	}
}

[Serializable]
class PlayerData {
	public int numClicks = 0;
	public DateTime lastClick = System.DateTime.Now;
	public int lastLevelCompleted = 0;
}