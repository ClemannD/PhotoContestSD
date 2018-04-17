using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailurePopupValues : MonoBehaviour {

	public Button ok;
	public Text error;

	public void SetErrorMessage(string message){
		this.error.text = message;
	}

}
