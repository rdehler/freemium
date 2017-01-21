// Check Box Additional Parameters (c)Dynamic Arts http://dynamicarts.com


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;
using DArts;

namespace DArts {


public class DAChkBox : MonoBehaviour {

	[SerializeField]
	private Color m_CheckColor;
	public string param_01;
	public string param_02;

	

	void Start() {
		//transform.Find("Background/Checkmark").GetComponent<Image>().color = m_CheckColor;
	}


	void Reset() {
		param_01 = "";
		param_02 = "";
	}





}
}
