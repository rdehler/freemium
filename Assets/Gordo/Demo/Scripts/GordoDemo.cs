// Gordo! Demo Presentation (c)Dynamic Arts http://dynamicarts.com


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DArts;

namespace DArts {


public class GordoDemo : MonoBehaviour {

	public GameObject m_ObjectToAnimate;

	private Animator ac;
	private AnimatorControllerParameter[] ac_parms;

	// Use this for initialization
	void Start () {
		ac = m_ObjectToAnimate.GetComponent<Animator>();
		ac_parms = ac.parameters;
	}
	


	// NEW Start Specific Animation ==========
	public void clickAnimation(bool is_on) {

		if (is_on) {

			// Selected Toggle
			Toggle my_toggle = EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>();
			
			// Trigger name
			string trig_name = my_toggle.GetComponent<DAChkBox>().param_01;

			// If trigger exists in Animation Controller, Set Trigger
			bool ok = false;
			for (int i=0;  i < ac_parms.Length; i++) if (ac_parms[i].name == trig_name) ok = true;
			if (ok) {
				ac.SetBool(trig_name, true);
			}

		}

	}




	void Reset() {
		m_ObjectToAnimate = GameObject.Find("Gordo");
	}

}
}