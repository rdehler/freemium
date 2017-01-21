using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DArts;

namespace DArts {


	public class ClickRegistration : MonoBehaviour {

		public GameObject m_ObjectToAnimate;

		private Animator ac;

		void Start () {
			ac = m_ObjectToAnimate.GetComponent<Animator>();
		}
		
		public void clickAnimation(bool is_on) {
			if (is_on) {
				ac.SetBool ("Hi_01", true);
				if (GameControl.control.hasBeenLongEnough ()) {
					registerClick ();
				} else {
					Debug.Log ("Hasn't been long enough!");
				}
			}

		}

		void registerClick() {
			GameControl.control.numClicks += 1;
			if (GameControl.control.numClicks > Constants.MAX_LEVELS) {
				//GameControl.control.numClicks = 1;
			}

			GameControl.control.addPlayerPoints ();

			// probably don't want this on every click...
			GameControl.control.Save ();
			GameControl.control.lastLevelCompleted += 1;
		}


		void Reset() {
			m_ObjectToAnimate = GameObject.Find("Gordo");
		}

	}
}