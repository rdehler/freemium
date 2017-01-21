using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBalloonController : MonoBehaviour {

	public SpriteRenderer renderer;

	public static SpeechBalloonController control;

	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}

	void Awake () {
		if (control == null) {
			control = this;
		}
	}

	public void hide() {
		renderer.enabled = false;
	}

	public void show() {
		renderer.enabled = true;
	}

}
