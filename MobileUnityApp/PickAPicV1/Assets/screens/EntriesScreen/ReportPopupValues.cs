using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportPopupValues : MonoBehaviour {

	public Button yes;
	public Button cancel;

	public Text message;

	public void SetMessage(string message){
		this.message.text = message;
	}

}
