using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekButtonPrefabValues : MonoBehaviour {

	public Text buttonText;
	public Button weekButton;



	public void SetButtonText(string weekInfo){
		this.buttonText.text = weekInfo;
	}


}
