using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConvoTextController : MonoBehaviour {

	public static ConvoTextController control;

	public Text convo;

	DateTime timeToClear;
	DateTime lastConvo = DateTime.Now;

	// Use this for initialization
	void Start () {
		convo = GetComponent<Text> ();
	}

	public void setContent(string content, int numSeconds) {
		control.convo.text = content;

		if (content == "") {
			SpeechBalloonController.control.hide ();
		} else {
			SpeechBalloonController.control.show ();
			timeToClear = DateTime.Now.AddSeconds (numSeconds);
		}

		lastConvo = DateTime.Now;
	}

	public void setContent(string content) {
		setContent(content, Constants.TEXT_TIMEOUT_SECONDS);
	}

	void Awake () {
		if (control == null) {
			control = this;
		}
	}

	void Update() {
		if (control.convo.text != "" && DateTime.Now > timeToClear) {
			setContent ("");
		}

		if (lastConvo.AddSeconds (Constants.BORED_TIMEOUT) < DateTime.Now) {
			System.Random rnd = new System.Random ();
			string boredContent = "";

			int boredNum = rnd.Next (0, Constants.NUM_BORED);

			if (Constants.DIALOG.TryGetValue ("BORED_" + boredNum, out boredContent)) {
				setContent (boredContent, Constants.BORED_TIMEOUT);
			}

			

		}
	}
}
