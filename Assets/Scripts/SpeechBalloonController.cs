using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBalloonController : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	public static SpeechBalloonController control;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Awake () {
		if (control == null) {
			control = this;
		}
	}

	public void hide() {
		spriteRenderer.enabled = false;
	}

	public void show() {
		spriteRenderer.enabled = true;
	}

}
